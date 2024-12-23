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
    | while_stmt
    | label COLON block
    ;

simple_statements
    : pass_statement
    | jump
    | label
    | call
    | return
    | say
    | python_one_line
    | window
    | scene
    | pause
    | show
    | hide
    ;

// https://www.renpy.org/doc/html/displaying_images.html#hide-and-show-window
window
    : WINDOW (SHOW | HIDE) expression?
    ;

scene
    : SCENE NAME+ (WITH expression)?
    | SCENE EXPRESSION expression (WITH expression)?
    ;

pause
    : PAUSE
    ;

// https://www.renpy.org/doc/html/displaying_images.html#show-statement
// TODO: A ton of missing clauses here.
show
    : SHOW NAME+ (WITH expression)?
    | SHOW EXPRESSION expression (WITH expression)?
    ;

// https://www.renpy.org/doc/html/displaying_images.html#hide-statement
hide
    : HIDE NAME+ (WITH expression)?
    | HIDE EXPRESSION expression (WITH expression)?
    ;

python_one_line
    : DOLLAR python_statement
    ;

python_statement
    : assignment
    | expression
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
    | single_target augassign expression
    ;

augassign
    : '+='
    | '-='
    | '*='
    //| '@=' Seems to be matrix multiplication. Couldn't find documentation on how to do this outside of numpy.
    | '/='
    | '%='
    | '&='
    | '|='
    | '^='
    | '<<='
    | '>>='
    | '**='
    | '//=';

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

while_stmt
    : 'while' named_expression ':' block else_block?;

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
    : comparison
    ;

// Comparison operators
// --------------------

// disjunction > conjunction > inversion > comparison >
comparison
    : bitwise_or (comparison_operator comparison)?;

comparison_operator
    : EQEQUAL
    | NOTEQUAL
    | LESSEQUAL
    | LESS
    | GREATEREQUAL
    | GREATER
    | NOT? IN
    | IS NOT?
    ;

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
    : primary ('.' name | '(' arguments? ')' | '[' slices ']')
    | atom
    ;

atom
    : strings
    | list
    | dict
    | name
    | TRUE
    | FALSE
    | NONE
    | NUMBER
    ;

name
    : NAME
    | PAUSE
    | MENU
    | WINDOW
    | SHOW
    | HIDE
    | PAUSE
    | EXPRESSION
    | CALL
    | LABEL
    | JUMP
    | SCENE
    | BEHIND
    | ONLAYER
    | AS
    | AT;

strings
    : (STRING)+
    ;

single_target
    : single_subscript_attribute_target
    | name
    | '(' single_target ')';

single_subscript_attribute_target
    : t_primary ('.' name | '[' slices ']')
    ;

t_primary
    : t_primary  ('.' name | genexp | '(' arguments? ')' | '[' slices ']')
    | name
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
    : name '=' expression
    | '**' expression;

kwarg_or_starred
    : name '=' expression
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
    : name ':=' expression;

named_expression
    : assignment_expression
    | expression;
