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
    | if_stmt
    | label COLON block
    ;

simple_statements
    : pass_statement
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
    : MENU (label_name)? COLON NEWLINE INDENT (say NEWLINE)? (menu_item)+ DEDENT
    ;

menu_item
    : STRING COLON block
    ;

pass_statement
    : PASS
    ;

label
    // https://www.renpy.org/doc/html/label.html
    : LABEL label_name ('(' (parameters) ')')? COLON? // blocks aren't actually required.
    ;

label_name
    : DOT? NAME
    ;

jump
    : JUMP label_name
    | JUMP EXPRESSION expression
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

parameters
    // SyntaxError: at least one argument must precede /
    // SyntaxError: named arguments must follow bare *
    : (((param_no_default+ param_with_default*) | (param_no_default* param_with_default+)) ('/' ','))? param_with_default*                   (('*' ',')? param_with_default+)? kwds?
    |                                                                   (param_no_default+ ('/' ','))? param_no_default* param_with_default* (('*' ',')? param_with_default+)? kwds?
    |                                                                   (param_no_default+ ('/' ','))? param_no_default*                     (('*' ',')? ((param_no_default+ param_with_default*) | (param_no_default* param_with_default+)))? kwds?
    ;
    //: slash_no_default param_no_default* param_with_default* star_etc?
    //| slash_with_default param_with_default* star_etc?
    //| param_no_default+ param_with_default* star_etc?
    //| param_with_default+ star_etc?
    //| star_etc;

kwds
    : '**' param_no_default;

param_no_default
    : param ','? type_comment?
    ;

param_with_default
    : param default_assignment ','? type_comment?
    ;

param
    : NAME annotation?
    ;

annotation
    : ':' expression
    ;

default_assignment
    : '=' expression
    ;

// No idea what the best way to parse this is, but I think type comments
// are a subset of expressions.
type_comment
    : '->' expression;

// If statement
// ------------

if_stmt
    : 'if' named_expression ':' block (elif_stmt | else_block?)
    ;
elif_stmt
    : 'elif' named_expression ':' block (elif_stmt | else_block?)
    ;
else_block
    : 'else' ':' block;

// Lists
// -----

list
    : '[' star_named_expressions? ']';

tuple
    : '(' (star_named_expression ',' star_named_expressions?  )? ')';

set: LBRACE star_named_expressions RBRACE;

// Dicts
// -----

dict
    : LBRACE double_starred_kvpairs? RBRACE;

double_starred_kvpairs: double_starred_kvpair (',' double_starred_kvpair)* ','?;

double_starred_kvpair
    //: '**' bitwise_or
    : '**' sum
    | kvpair;

kvpair: expression ':' expression;

//
// Expressions
//

star_expression
    //: '*' bitwise_or
    : '*' sum
    | expression;

expression
    : bitwise_or
    ;

// disjunction > conjunction > inversion > comparison > compare_op_bitwise_or_pair > 
bitwise_or
    //: bitwise_or '|' bitwise_xor
    //| bitwise_xor;
    : sum
    ;

// bitwise_or > bitwise_xor > bitwise_and > shift_expr > sum
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
    | list
    | dict
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

// More like kwargs-ish, since it allows starred_expression's.
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

slices
  //: slice
    : named_expression
  //| (slice | starred_expression) (',' (slice | starred_expression))* ','?
    ;

star_named_expressions: star_named_expression (',' star_named_expression)* ','?;

star_named_expression
    //: '*' bitwise_or
    : '*' sum
    | named_expression;

// Would have expected NAME to be a single_target to allow for assignment to any data store.
assignment_expression
    : NAME ':=' expression;

named_expression
    : assignment_expression
    | expression;
