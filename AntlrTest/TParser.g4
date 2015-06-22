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
variableDeclarationStatement : PREDEFINEDTYPE variableDeclarator SCOL;
variableDeclarator : ID equalsValueClause;
equalsValueClause : ASSIGN expression;
expression
    : int32LiteralExpression
    | booleanLiteralExpression
    | unitLiteralExpression;
int32LiteralExpression : INTVALUE;
booleanLiteralExpression : TRUE | FALSE;
unitLiteralExpression : UNIT;