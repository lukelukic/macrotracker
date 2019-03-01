ú
?D:\macrotracker\MacroTracker\MacroTracker.ApiGateway\Program.cs
	namespace 	
MacroTracker
 
. 

ApiGateway !
{ 
public 

static 
class 
Program 
{ 
public		 
static		 
void		 
Main		 
(		  
string		  &
[		& '
]		' (
args		) -
)		- .
{

 	 
CreateWebHostBuilder  
(  !
args! %
)% &
.& '
Build' ,
(, -
)- .
.. /
Run/ 2
(2 3
)3 4
;4 5
} 	
public 
static 
IWebHostBuilder % 
CreateWebHostBuilder& :
(: ;
string; A
[A B
]B C
argsD H
)H I
=>J L
WebHost 
.  
CreateDefaultBuilder (
(( )
args) -
)- .
. %
ConfigureAppConfiguration *
(* +
(+ ,
hostingContext, :
,: ;
config< B
)B C
=>D F
{ 
config 
. 
AddJsonFile &
(& '
$str' 4
)4 5
;5 6
} 
) 
. 

UseStartup 
< 
Startup #
># $
($ %
)% &
;& '
} 
} à
?D:\macrotracker\MacroTracker\MacroTracker.ApiGateway\Startup.cs
	namespace		 	
MacroTracker		
 
.		 

ApiGateway		 !
{

 
public 

class 
Startup 
{ 
public 
Startup 
( 
IConfiguration %
configuration& 3
)3 4
{ 	
Configuration 
= 
configuration )
;) *
} 	
public 
IConfiguration 
Configuration +
{, -
get. 1
;1 2
}3 4
public 
void 
ConfigureServices %
(% &
IServiceCollection& 8
services9 A
)A B
{ 	
services 
. 
AddMvc 
( 
) 
. #
SetCompatibilityVersion 5
(5 6 
CompatibilityVersion6 J
.J K
Version_2_2K V
)V W
;W X
services 
. 
	AddOcelot 
( 
)  
;  !
} 	
public 
void 
	Configure 
( 
IApplicationBuilder 1
app2 5
,5 6
IHostingEnvironment7 J
envK N
)N O
{ 	
if 
( 
env 
. 
IsDevelopment !
(! "
)" #
)# $
{ 
app   
.   %
UseDeveloperExceptionPage   -
(  - .
)  . /
;  / 0
}!! 
else"" 
{## 
app%% 
.%% 
UseHsts%% 
(%% 
)%% 
;%% 
}&& 
app(( 
.(( 
	UseOcelot(( 
((( 
)(( 
.(( 
Wait((  
(((  !
)((! "
;((" #
})) 	
}** 
}++ 