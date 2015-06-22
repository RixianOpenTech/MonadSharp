lexer grammar TLexer;

fragment DIGIT : [0-9] ;

BinaryOperatorToken
    : OR
    | AND
    | EQ
    | NEQ
    | GT
    | LT
    | GTEQ
    | LTEQ
    | PLUS
    | MINUS
    | MULT
    | DIV
    | POW
    | MOD;

PARALLEL_MODIFIER : PARALLEL | SERIAL;
ACCESS_MODIFIER : PUBLIC | PRIVATE;

PREDEFINEDTYPE
    : INT
    | STRING
    | BOOL
    | UNIT;

// Keywords
PUBLIC : 'public';
PRIVATE : 'private';
SERIAL : 'serial';
PARALLEL : 'parallel';

INT : 'int';
STRING : 'string';
BOOL : 'bool';
UNIT : 'unit';

TRUE : 'true';
FALSE : 'false';
NULL : 'null';
IF : 'if';
ELSE : 'else';
WHILE : 'while';
RANGE : 'range';

// Operators
OR : '||';
AND : '&&';
EQ : '==';
NEQ : '!=';
GT : '>';
LT : '<';
GTEQ : '>=';
LTEQ : '<=';
PLUS : '+';
MINUS : '-';
MULT : '*';
DIV : '/';
MOD : '%';
POW : '^';
NOT : '!';
RANGEDOTS : '..';

ASSIGN : '=';
OPAR : '(';
CPAR : ')';
OBRACE : '{';
CBRACE : '}';

COMMA : ',';
PERIOD : ',';
SCOL : ';';

ID : [a-zA-Z_] [a-zA-Z_0-9]*;

INTVALUE
 : [0-9]+
 ;

FLOATVALUE
 : [0-9]+ '.' [0-9]*
 | '.' [0-9]+
 ;

STRINGVALUE
 : '"' (~["\r\n] | '""')* '"'
 ;

COMMENT
 : '#' ~[\r\n]* -> skip
 ;

SPACE
 : [ \t\r\n]* -> skip
 ;

OTHER
 : .
 ;


WS  :   ( ' '
        | '\t'
        | '\r'
        | '\n'
        )* -> channel(HIDDEN)
    ;