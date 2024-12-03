parser grammar RenpyParser;
options {
    tokenVocab=RenpyLexer;
    superClass=RenpyParserBase;
}

entire_tree: statements? NEWLINE* EOF;

statements
    : statement+
    ;

statement
    : simple_statements NEWLINE
    | block_statements
    ;

// These don't have a required trailing newline.
block_statements
    : menu
    | label COLON block
    ;

simple_statements
    : pass_statement
    | menu
    | jump
    | label
    | call
    | return
    | say
    | assignment
    ;

block
    : NEWLINE INDENT statements DEDENT
    ;

menu
    : MENU label_name? COLON NEWLINE INDENT (say NEWLINE)? (menu_item)+ DEDENT
    ;

menu_item
    : STRING COLON block
    ;

pass_statement
    : PASS
    ;

label
    // https://www.renpy.org/doc/html/label.html
    : LABEL label_name ('(' (arguments)? ')')? COLON? // blocks aren't actually required.
    ;

label_name
    : DOT? NAME
    ;

jump
    : jump_constant
    ;

jump_constant
    : JUMP expression
    ;

call
    : CALL label_name ( '(' arguments? ')')?
    ;

return
    : return_simple
    ;

return_simple
    : RETURN
    ;

say
    : NAME STRING
    | STRING
    ;

assignment
    : single_target EQUALS expression
    ;

//
// Expressions
//

expression
    : sum
    ;

// disjunction > conjunction > inversion > comparison > compare_op_bitwise_or_pair > bitwise_or > bitwise_xor > bitwise_and > shift_expr > sum
sum
    : sum (PLUS | MINUS) primary
    | primary
    ;

// term > factor > power > await primary > primary
primary
    //: primary ('.' NAME | genexp | '(' arguments? ')' | '[' slices ']')
    : primary ('.' NAME | '(' arguments? ')' | '[' slices ']')
    | atom
    ;

atom
    : strings
    | NAME
    | TRUE
    | FALSE
    | NONE
    | NUMBER
    ;

strings
    : (STRING)+
    ;

single_target
    : single_subscript_attribute_target
    | NAME
    | '(' single_target ')';

single_subscript_attribute_target
    : t_primary ('.' NAME | '[' slices ']')
    ;

t_primary
    : t_primary  ('.' NAME | genexp | '(' arguments? ')' | '[' slices ']')
    | NAME
    ;

genexp
    //: '(' ( assignment_expression | expression) for_if_clauses ')';
    : '(' ( assignment_expression | expression) ')'
    ;

// FUNCTION CALL ARGUMENTS
// =======================

arguments
    : args ','?;

args
    : (starred_expression | ( assignment_expression | expression)) (',' (starred_expression | ( assignment_expression | expression)))* (',' kwargs )?
    | kwargs;

kwargs
    : kwarg_or_starred (',' kwarg_or_starred)* (',' kwarg_or_double_starred (',' kwarg_or_double_starred)*)?
    | kwarg_or_double_starred (',' kwarg_or_double_starred)*
    ;

starred_expression
    : '*' expression;

kwarg_or_double_starred
    : NAME '=' expression
    | '**' expression;

kwarg_or_starred
    : NAME '=' expression
    | starred_expression;

// Would have expected NAME to be a single_target to allow for assignment to any data store.
assignment_expression
    : NAME ':=' expression;

slices
  //: slice
    : named_expression
  //| (slice | starred_expression) (',' (slice | starred_expression))* ','?
    ;

named_expression
    : assignment_expression
    | expression;
