parser grammar DcParser;

options
    { tokenVocab=DcTokens; }

init : (import_statement)* dc_declaration* ;

dc_declaration  
  : (typedef_declaration | class_declaration | struct_declaration | keyword_declaration) ';'
  ;

// Import statements
import_statement 
  : FROM module_path module_extension? IMPORT module_name module_extension?
  | IMPORT module_path module_extension?
  ;

module_path : IDENTIFIER ('.' IDENTIFIER)* ;
module_name : (STAR | (IDENTIFIER module_extension?)) ;
module_extension : ('/' IDENTIFIER)+ ;

// Class declaration
class_declaration : DCLASS name=IDENTIFIER (':' parents=parent_class_list)? '{' (class_field ';')* '}';

parent_class_list 
  : name=IDENTIFIER 
  | name=IDENTIFIER ',' next=parent_class_list 
  ;

class_field : atomic_field | molecular_field | parameter_field ;

// Struct declaration
struct_declaration : STRUCT name=IDENTIFIER '{' (class_field ';')* '}' ;

// Fields
parameter_field : parameter keywords=keyword_list? ; 

atomic_field : name=IDENTIFIER '(' parameters=field_parameters? ')' keywords=keyword_list? ;

field_parameters
  : p=parameter
  | p=parameter ',' next=field_parameters
  ;

molecular_field : name=IDENTIFIER ':' members=molecular_field_members ;

molecular_field_members
  : name=IDENTIFIER
  | name=IDENTIFIER ',' next=molecular_field_members
  ;

// Keywords
keyword_declaration : KEYWORD name=IDENTIFIER ;

keyword_list
  : keyword=(IDENTIFIER | HISTORIC_KW)
  | keyword=(IDENTIFIER | HISTORIC_KW) next=keyword_list
  ;

// Typedefs
typedef_declaration : TYPEDEF p=parameter ;

// Parameters
parameter 
  : type=(BUILTIN_TYPE | IDENTIFIER) ('%' modulus=UNSIGNED_NUMBER)? ('/' divisor=UNSIGNED_NUMBER)? parameter_range? name=IDENTIFIER? array=array_specification?  default_value? ;

array_specification
  : '[' range=range_arguments? ']'
  | '[' range=range_arguments? ']' next=array_specification
  ;

// Ranges
parameter_range : '(' range_arguments ')' ;
range_arguments 
  : range_argument
  | range_argument ',' next=range_arguments
  ;

range_argument
  : single=number_constant
  | char=QUOTED_CHAR
  | min=number_constant '-' max=number_constant
  ;

// Default values
default_value 
  : '=' value=value_constant ;

value_constant : number_constant | string_constant | struct_constant | array_constant ;

number_constant 
  : '-' UNSIGNED_NUMBER
  | UNSIGNED_NUMBER
  ;

string_constant 
  : SINGLE_QUOTED_STRING 
  | DOUBLE_QUOTED_STRING
  | QUOTED_CHAR 
  ;

struct_constant
  : '{' struct_value_list? '}'
  ;
  
struct_value_list
  : value_constant
  | value_constant ',' next=struct_value_list
  ;

array_constant 
  : '[' array_value_list? ']'
  ;

array_value_list
  : array_value_constant
  | array_value_constant ',' next=array_value_list
  ;
  
array_value_constant 
  : value_constant '*' t=UNSIGNED_NUMBER
  | value_constant
  ;
