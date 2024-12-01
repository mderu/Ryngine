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
    : label_constant
    ;

label_constant
    : LABEL label_name COLON? // blocks aren't actually required.
    ;

label_name
    : DOT? NAME
    ;

jump
    : jump_constant
    ;

jump_constant
    : JUMP label_name
    ;

call
    : call_constant
    ;

call_constant
    : CALL label_name
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
