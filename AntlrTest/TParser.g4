parser grammar TParser;

invocationExpression : expression OPAR argumentList CPAR;
argumentList : expression*;

rangeLoop : RANGE OPAR rangeExpression CPAR block;
rangeExpression : expression RANGEDOTS expression;

ifStatement : IF OPAR expression CPAR block elseStatement?;
elseStatement : ELSE (ifStatement|block);

methodDeclaration : PARALLEL_MODIFIER? ACCESS_MODIFIER? PREDEFINEDTYPE ID OPAR parameterList? CPAR block;
parameterList : parameter (COMMA parameter)*;
parameter : PREDEFINEDTYPE ID;

block
    : OBRACE statement* CBRACE
    | statement;

statement
    : variableDeclarationStatement
    | ifStatement
    | rangeLoop;

// Variables
variableDeclarationStatement : PREDEFINEDTYPE variableDeclarator SCOL;
variableDeclarator : ID equalsValueClause;
equalsValueClause : ASSIGN expression;

expression
    : literalExpression;

literalExpression
    : int32LiteralExpression
    | booleanLiteralExpression
    | stringLiteralExpression
    | unitLiteralExpression;

//Literal Expressions
int32LiteralExpression : INTVALUE;
booleanLiteralExpression : TRUE | FALSE;
stringLiteralExpression : STRINGVALUE;
unitLiteralExpression : UNIT;


binaryOperatorToken
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

// Keyword Types
parallelModifier : PARALLEL | SERIAL;
accessModifier : PUBLIC | PRIVATE;

predefinedType
    : INT
    | STRING
    | BOOL
    | UNIT;