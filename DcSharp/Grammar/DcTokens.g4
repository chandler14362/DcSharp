lexer grammar DcTokens;

DCLASS : 'dclass' ;
STRUCT : 'struct' ;
TYPEDEF : 'typedef' ;
KEYWORD : 'keyword' ;

FROM : 'from' ;
IMPORT : 'import' ;

fragment REQUIRED: 'required' ;
fragment BROADCAST: 'broadcast' ;
fragment OWNRECV: 'ownrecv' ;
fragment RAM: 'ram' ;
fragment DB: 'db' ;
fragment CLSEND: 'clsend' ;
fragment CLRECV: 'clrecv' ;
fragment OWNSEND: 'ownsend' ;
fragment AIRECV: 'airecv' ;

HISTORIC_KW: REQUIRED | BROADCAST | OWNRECV | RAM | DB | CLSEND | CLRECV | OWNRECV | AIRECV ;

fragment UINT32UINT8ARRAY: 'uint32uint8array' ;
fragment INT32ARRAY: 'int32array' ;
fragment INT16ARRAY: 'int16array' ;
fragment INT8ARRAY: 'int8array' ;
fragment UINT32ARRAY: 'uint32array' ;
fragment UINT16ARRAY: 'uint16array' ;
fragment UINT8ARRAY: 'uint8array' ;

fragment UINT64: 'uint64' ;
fragment UINT32: 'uint32' ;
fragment UINT16: 'uint16' ;
fragment UINT8: 'uint8' ;
fragment INT64: 'int64' ;
fragment INT32: 'int32' ;
fragment INT16: 'int16' ;
fragment INT8: 'int8' ;

fragment STRING: 'string' ;
fragment BLOB32: 'blob32' ;
fragment BLOB: 'blob' ;

BUILTIN_TYPE : UINT32UINT8ARRAY | INT32ARRAY | INT16ARRAY | INT8ARRAY | UINT32ARRAY | UINT16ARRAY | UINT8ARRAY |
    UINT64 | UINT32 | UINT16 | UINT8 | INT64 | INT32 | INT16 | INT8 | STRING | BLOB32 | BLOB ;

STAR : '*' ;
FWSLASH : '/' ;
MODULUS : '%' ;
PERIOD : '.' ;
LPAREN : '(' ;
RPAREN : ')' ;
HYPEN : '-' ;
COMMA : ',' ;
LSBRACKET : '[' ;
RSBRACKET : ']' ;
LBRACKET : '{' ;
RBRACKET : '}' ;
SINGLE_QUOTE : '\'' ;
DOUBLE_QUOTE : '"' ;
EQUALS : '=' ;
SEMICOLON : ';' ;
COLON : ':' ;

fragment ESCAPED_DOUBLE_QUOTE : '\\"' ;
DOUBLE_QUOTED_STRING : '"' ( ESCAPED_DOUBLE_QUOTE | ~('\n'|'\r') )*? '"' ;

QUOTED_CHAR : '\'' CHAR '\'' ;

fragment ESCAPED_SINGLE_QUOTE : '\\\'' ;
SINGLE_QUOTED_STRING : '\'' ( ESCAPED_SINGLE_QUOTE | ~('\n'|'\r') )*? '\'' ;

IDENTIFIER : [A-Za-z_][A-Za-z_0-9]* ;
UNSIGNED_NUMBER : [0-9]+ ;
CHAR : [a-zA-Z] ;

SINGLE_LINE_COMMENT : '//' .*? '\n' -> skip ;

// skip whitespace
WS : [ \t\r\n]+ -> skip ;
