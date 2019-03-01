¿
QD:\macrotracker\MacroTracker\MacroTracker.Emails\Extensions\EventBusExtensions.cs
	namespace

 	
MacroTracker


 
.

 
Emails

 
.

 

Extensions

 (
{ 
public 

static 
class 
EventBusExtensions *
{ 
public 
static 
void 
ManageSubscriptions .
(. /
this/ 3
	IEventBus4 =
bus> A
,A B
IEmailSenderC O
senderP V
)V W
{ 	
bus 
. 
	Subscribe 
< 
UserRegisteredEvent -
>- .
(. /
$str/ E
,E F
eG H
=>I K
{ 
var 
handler 
= 
new !*
UserRegisteredEventMailHandler" @
(@ A
eA B
)B C
;C D
handler 
. 
Handle 
( 
sender %
)% &
;& '
} 
) 
; 
bus 
. 
	Subscribe 
<  
UserDeactivatedEvent .
>. /
(/ 0
$str0 G
,G H
eI J
=>K M
{ 
var 
handler 
= 
new !+
UserDeactivatedEventMailHandler" A
(A B
eB C
)C D
;D E
handler 
. 
Handle 
( 
sender %
)% &
;& '
} 
) 
; 
} 	
} 
} ¦
KD:\macrotracker\MacroTracker\MacroTracker.Emails\Interfaces\IEmailSender.cs
	namespace 	
MacroTracker
 
. 
Emails 
. 

Interfaces (
{ 
public 

	interface 
IEmailSender !
{ 
string 
Body 
{ 
get 
; 
set 
; 
}  !
string 
Subject 
{ 
get 
; 
set !
;! "
}# $
string 
ToEmail 
{ 
get 
; 
set !
;! "
}# $
void		 
Send		 
(		 
)		 
;		 
}

 
} Ç
MD:\macrotracker\MacroTracker\MacroTracker.Emails\MailHandlers\EmailHandler.cs
	namespace 	
MacroTracker
 
. 
Emails 
. 
MailHandlers *
{		 
public

 

abstract

 
class

 
EmailHandler

 &
<

& '
TEvent

' -
>

- .
where

/ 4
TEvent

5 ;
:

< =
IEvent

> D
{ 
	protected 
readonly 
TEvent !
_event" (
;( )
	protected 
EmailHandler 
( 
TEvent %
@event& ,
), -
=>. 0
_event1 7
=8 9
@event: @
;@ A
public 
string 
	QueueName 
=>  "
GetType# *
(* +
)+ ,
., -
Name- 1
;1 2
	protected 
abstract 
string !
Body" &
{' (
get) ,
;, -
}. /
	protected 
abstract 
string !
Subject" )
{* +
get, /
;/ 0
}1 2
	protected 
abstract 
string !
ToEmail" )
{* +
get, /
;/ 0
}1 2
public 
virtual 
void 
Handle "
(" #
IEmailSender# /
sender0 6
)6 7
{ 	
sender 
. 
Body 
= 
Body 
; 
sender 
. 
Subject 
= 
Subject $
;$ %
sender 
. 
ToEmail 
= 
ToEmail $
;$ %
sender 
. 
Send 
( 
) 
; 
} 	
} 
} ­
`D:\macrotracker\MacroTracker\MacroTracker.Emails\MailHandlers\UserDeactivatedEventMailHandler.cs
	namespace 	
MacroTracker
 
. 
Emails 
. 
MailHandlers *
{ 
public		 

class		 +
UserDeactivatedEventMailHandler		 0
:		1 2
EmailHandler		3 ?
<		? @ 
UserDeactivatedEvent		@ T
>		T U
{

 
public +
UserDeactivatedEventMailHandler .
(. / 
UserDeactivatedEvent/ C
@eventD J
)J K
:L M
baseN R
(R S
@eventS Y
)Y Z
{ 	
} 	
	protected 
override 
string !
Body" &
=>' )
$"* ,
Dear , 1
{1 2
_event2 8
.8 9
	FirstName9 B
}B C
, C E
"E F
+G H
$", .A
5</br> You have successfully deactivated your account.. c
"c d
+e f
$", .

</br></br>. 8
"8 9
+: ;
$", .0
$Best regards, </br> Macrotracker LLC. R
"R S
;S T
	protected 
override 
string !
Subject" )
=>* ,
$str- D
;D E
	protected 
override 
string !
ToEmail" )
=>* ,
_event- 3
.3 4
Email4 9
;9 :
} 
} ‰	
_D:\macrotracker\MacroTracker\MacroTracker.Emails\MailHandlers\UserRegisteredEventMailHandler.cs
	namespace 	
MacroTracker
 
. 
Emails 
. 
MailHandlers *
{ 
public		 

class		 *
UserRegisteredEventMailHandler		 /
:		0 1
EmailHandler		2 >
<		> ?
UserRegisteredEvent		? R
>		R S
{

 
public *
UserRegisteredEventMailHandler -
(- .
UserRegisteredEvent. A
@eventB H
)H I
:J K
baseL P
(P Q
@eventQ W
)W X
{ 	
} 	
	protected 
override 
string !
Body" &
=>' )
$str* E
;E F
	protected 
override 
string !
Subject" )
=>* ,
$str- ;
;; <
	protected 
override 
string !
ToEmail" )
=>* ,
_event- 3
.3 4
Email4 9
;9 :
} 
} ¿
HD:\macrotracker\MacroTracker\MacroTracker.Emails\Options\EmailOptions.cs
	namespace 	
MacroTracker
 
. 
Emails 
. 
Options %
{ 
public 

class 
EmailOptions 
{ 
public 
string 
	FromEmail 
{  !
get" %
;% &
set' *
;* +
}, -
public 
string 
FromPassword "
{# $
get% (
;( )
set* -
;- .
}/ 0
public 
string 
FromName 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
int 
Port 
{ 
get 
; 
set "
;" #
}$ %
public		 
string		 
Host		 
{		 
get		  
;		  !
set		" %
;		% &
}		' (
}

 
} Š	
;D:\macrotracker\MacroTracker\MacroTracker.Emails\Program.cs
	namespace 	
MacroTracker
 
. 
Emails 
{ 
public 

static 
class 
Program 
{ 
public 
static 
void 
Main 
(  
string  &
[& '
]' (
args) -
)- .
=>/ 1 
CreateWebHostBuilder2 F
(F G
argsG K
)K L
.L M
BuildM R
(R S
)S T
.T U
RunU X
(X Y
)Y Z
;Z [
public

 
static

 
IWebHostBuilder

 % 
CreateWebHostBuilder

& :
(

: ;
string

; A
[

A B
]

B C
args

D H
)

H I
=>

J L
WebHost 
.  
CreateDefaultBuilder (
(( )
args) -
)- .
. 

UseStartup 
< 
Startup #
># $
($ %
)% &
;& '
} 
} Ô
JD:\macrotracker\MacroTracker\MacroTracker.Emails\Senders\SmtpMailSender.cs
	namespace 	
MacroTracker
 
. 
Emails 
. 
Senders %
{ 
public		 

class		 
SmtpMailSender		 
:		  !
IEmailSender		" .
{

 
private 
readonly 
EmailOptions %
_options& .
;. /
public 
string 
ToEmail 
{ 
get  #
;# $
set% (
;( )
}* +
public 
string 
Subject 
{ 
get  #
;# $
set% (
;( )
}* +
public 
string 
Body 
{ 
get  
;  !
set" %
;% &
}' (
public 
SmtpMailSender 
( 
EmailOptions *
options+ 2
)2 3
=>4 6
_options7 ?
=@ A
optionsB I
;I J
public 
SmtpMailSender 
( 
IOptions &
<& '
EmailOptions' 3
>3 4
options5 <
)< =
=>> @
_optionsA I
=J K
optionsL S
.S T
ValueT Y
;Y Z
public 
void 
Send 
( 
) 
{ 	
var 
fromAddress 
= 
new !
MailAddress" -
(- .
_options. 6
.6 7
	FromEmail7 @
,@ A
_optionsB J
.J K
FromNameK S
)S T
;T U
var 
smtp 
= 
new 

SmtpClient %
{ 
Host 
= 
_options 
.  
Host  $
,$ %
Port 
= 
_options 
.  
Port  $
,$ %
	EnableSsl 
= 
true  
,  !
DeliveryMethod 
=  
SmtpDeliveryMethod! 3
.3 4
Network4 ;
,; <!
UseDefaultCredentials %
=& '
false( -
,- .
Credentials 
= 
new !
NetworkCredential" 3
(3 4
fromAddress4 ?
.? @
Address@ G
,G H
_optionsI Q
.Q R
FromPasswordR ^
)^ _
}   
;   
using"" 
("" 
var"" 
message"" 
=""  
new""! $
MailMessage""% 0
(""0 1
_options""1 9
.""9 :
	FromEmail"": C
,""C D
ToEmail""E L
)""L M
{## 
Subject$$ 
=$$ 
Subject$$ !
,$$! "
Body%% 
=%% 
Body%% 
}&& 
)&& 
{'' 
smtp(( 
.(( 
Send(( 
((( 
message(( !
)((! "
;((" #
})) 
}** 	
}++ 
},, š
;D:\macrotracker\MacroTracker\MacroTracker.Emails\Startup.cs
	namespace 	
MacroTracker
 
. 
Emails 
{ 
public 

class 
Startup 
{ 
public 
Startup 
( 
IConfiguration %
configuration& 3
)3 4
{ 	
Configuration 
= 
configuration )
;) *
} 	
public 
IConfiguration 
Configuration +
{, -
get. 1
;1 2
}3 4
public 
void 
ConfigureServices %
(% &
IServiceCollection& 8
services9 A
)A B
{ 	
services 
. 
AddTransient !
<! "
	IEventBus" +
,+ ,
RabbitMQEventBus- =
>= >
(> ?
eb 
=> 
{ 
var   
config   
=    
Configuration  ! .
.  . /

GetSection  / 9
(  9 :
$str  : D
)  D E
;  E F
return!! 
new!! 
RabbitMQEventBus!! /
(!!/ 0
config!!0 6
[!!6 7
$str!!7 =
]!!= >
,!!> ?
config!!@ F
[!!F G
$str!!G Q
]!!Q R
,!!R S
config!!T Z
[!!Z [
$str!![ e
]!!e f
)!!f g
;!!g h
}"" 
)"" 
;"" 
services$$ 
.$$ 
	Configure$$ 
<$$ 
EmailOptions$$ +
>$$+ ,
($$, -
options$$- 4
=>$$5 7
Configuration$$8 E
.$$E F

GetSection$$F P
($$P Q
$str$$Q X
)$$X Y
.$$Y Z
Bind$$Z ^
($$^ _
options$$_ f
)$$f g
)$$g h
;$$h i
services%% 
.%% 
AddTransient%% !
<%%! "
IEmailSender%%" .
,%%. /
SmtpMailSender%%0 >
>%%> ?
(%%? @
)%%@ A
;%%A B
}&& 	
public)) 
void)) 
	Configure)) 
()) 
IApplicationBuilder)) 1
app))2 5
,))5 6
IHostingEnvironment))7 J
env))K N
)))N O
{** 	
if++ 
(++ 
env++ 
.++ 
IsDevelopment++ !
(++! "
)++" #
)++# $
{,, 
app-- 
.-- %
UseDeveloperExceptionPage-- -
(--- .
)--. /
;--/ 0
}.. 
var00 
eventBus00 
=00 
app00 
.00 
ApplicationServices00 2
.002 3

GetService003 =
<00= >
	IEventBus00> G
>00G H
(00H I
)00I J
;00J K
var11 
emailService11 
=11 
app11 "
.11" #
ApplicationServices11# 6
.116 7

GetService117 A
<11A B
IEmailSender11B N
>11N O
(11O P
)11P Q
;11Q R
eventBus33 
.33 
ManageSubscriptions33 (
(33( )
emailService33) 5
)335 6
;336 7
app55 
.55 
Run55 
(55 
async55 
(55 
context55 "
)55" #
=>55$ &
await55' ,
context55- 4
.554 5
Response555 =
.55= >

WriteAsync55> H
(55H I
$str55I W
)55W X
)55X Y
;55Y Z
}66 	
}77 
}88 