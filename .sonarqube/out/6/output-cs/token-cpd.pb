‡
fD:\macrotracker\MacroTracker\MacroTracker.Users.Application\Exceptions\EntityAlreadyExistsException.cs
	namespace 	
MacroTracker
 
. 
Users 
. 
Application (
.( )

Exceptions) 3
{ 
[ 
Serializable 
] 
public 

class (
EntityAlreadyExistsException -
:. /
	Exception0 9
{ 
public (
EntityAlreadyExistsException +
(+ ,
), -
{		 	
}

 	
public (
EntityAlreadyExistsException +
(+ ,
string, 2
message3 :
): ;
:< =
base> B
(B C
messageC J
)J K
{ 	
} 	
} 
} 
aD:\macrotracker\MacroTracker\MacroTracker.Users.Application\Exceptions\EntityNotFoundException.cs
	namespace 	
MacroTracker
 
. 
Users 
. 
Application (
.( )

Exceptions) 3
{ 
public 

class #
EntityNotFoundException (
:) *
	Exception+ 4
{ 
public #
EntityNotFoundException &
(& '
)' (
{ 	
}		 	
public #
EntityNotFoundException &
(& '
Guid' +
id, .
,. /
string0 6

entityType7 A
)A B
:C D
baseE I
(I J
$"J L
{L M

entityTypeM W
}W X
 with an id of X g
{g h
idh j
}j k
 doesn't exist.k z
"z {
){ |
{ 	
} 	
} 
} Ç
fD:\macrotracker\MacroTracker\MacroTracker.Users.Application\Exceptions\UserAlreadyInactiveException.cs
	namespace 	
MacroTracker
 
. 
Users 
. 
Application (
{ 
[ 
Serializable 
] 
public 

class (
UserAlreadyInactiveException -
:. /
	Exception0 9
{ 
public		 (
UserAlreadyInactiveException		 +
(		+ ,
)		, -
{

 	
} 	
public (
UserAlreadyInactiveException +
(+ ,
string, 2
message3 :
): ;
:< =
base> B
(B C
messageC J
)J K
{ 	
} 	
public (
UserAlreadyInactiveException +
(+ ,
string, 2
message3 :
,: ;
	Exception< E
innerExceptionF T
)T U
:V W
baseX \
(\ ]
message] d
,d e
innerExceptionf t
)t u
{ 	
} 	
	protected (
UserAlreadyInactiveException .
(. /
SerializationInfo/ @
infoA E
,E F
StreamingContextG W
contextX _
)_ `
:a b
basec g
(g h
infoh l
,l m
contextn u
)u v
{ 	
} 	
} 
} Ÿ
TD:\macrotracker\MacroTracker\MacroTracker.Users.Application\Profiles\UserProfiles.cs
	namespace 	
MacroTracker
 
. 
Users 
. 
Application (
.( )
Profiles) 1
{ 
public		 

class		 
UserProfiles		 
:		 
Profile		  '
{

 
public 
UserProfiles 
( 
) 
{ 	
	CreateMap 
< 
RegisterUserUseCase )
,) *
User+ /
>/ 0
(0 1
)1 2
;2 3
	CreateMap 
< 
UpdateUserRequest '
,' (
User) -
>- .
(. /
)/ 0
;0 1
	CreateMap 
< 
User 
, 
UserDto #
># $
($ %
)% &
;& '
} 	
} 
} ¯
WD:\macrotracker\MacroTracker\MacroTracker.Users.Application\Repositories\IRepository.cs
	namespace 	
MacroTracker
 
. 
Users 
. 
Application (
.( )
Repositories) 5
{ 
public 

	interface 
IRepository  
<  !
T! "
>" #
where$ )
T* +
:, -
Entity. 4
{		 
IEnumerable

 
<

 
T

 
>

 
Get

 
(

 

Expression

 %
<

% &
Func

& *
<

* +
T

+ ,
,

, -
bool

. 2
>

2 3
>

3 4
	predicate

5 >
,

> ?
int

@ C
perPage

D K
,

K L
int

M P

pageNumber

Q [
)

[ \
;

\ ]
IEnumerable 
< 
T 
> 
Get 
( 

Expression %
<% &
Func& *
<* +
T+ ,
,, -
bool. 2
>2 3
>3 4
	predicate5 >
)> ?
;? @
T 	
Get
 
( 
Guid 
id 
) 
; 
T 	
Add
 
( 
T 
entity 
) 
; 
void 
Update 
( 
T 
entity 
) 
; 
void 
Delete 
( 
T 
entity 
) 
; 
void 
Delete 
( 
Guid 
id 
) 
; 
} 
} Î
^D:\macrotracker\MacroTracker\MacroTracker.Users.Application\Repositories\ITrainerRepository.cs
	namespace 	
MacroTracker
 
. 
Users 
. 
Application (
.( )
Repositories) 5
{ 
public 

	interface 
ITrainerRepository '
:( )
IRepository* 5
<5 6
Trainer6 =
>= >
{ 
void !
AcceptTrainingRequest "
(" #
Guid# '
	requestId( 1
)1 2
;2 3
}		 
}

 ¯
fD:\macrotracker\MacroTracker\MacroTracker.Users.Application\Repositories\ITrainingRequestRepository.cs
	namespace 	
MacroTracker
 
. 
Users 
. 
Application (
.( )
Repositories) 5
{ 
public 

	interface &
ITrainingRequestRepository /
:0 1
IRepository2 =
<= >
TrainingRequest> M
>M N
{ 
} 
} ◊
[D:\macrotracker\MacroTracker\MacroTracker.Users.Application\Repositories\IUserRepository.cs
	namespace 	
MacroTracker
 
. 
Users 
. 
Application (
.( )
Repositories) 5
{ 
public 

	interface 
IUserRepository $
:% &
IRepository' 2
<2 3
User3 7
>7 8
{ 
} 
} µ
|D:\macrotracker\MacroTracker\MacroTracker.Users.Application\UseCases\Trainers\AcceptTrainingRequest\AcceptTrainingRequest.cs
	namespace 	
MacroTracker
 
. 
Users 
. 
Application (
.( )
UseCases) 1
.1 2
Trainers2 :
.: ;!
AcceptTrainingRequest; P
{ 
public 

class !
AcceptTrainingRequest &
:' (
IRequest) 1
{ 
public 
Guid 
	RequestId 
{ 
get  #
;# $
set% (
;( )
}* +
}		 
}

 »
ÉD:\macrotracker\MacroTracker\MacroTracker.Users.Application\UseCases\Trainers\AcceptTrainingRequest\AcceptTrainingRequestHandler.cs
	namespace 	
MacroTracker
 
. 
Users 
. 
Application (
.( )
UseCases) 1
.1 2
Trainers2 :
.: ;!
AcceptTrainingRequest; P
{		 
public

 

class

 (
AcceptTrainingRequestHandler

 -
:

. /
IRequestHandler

0 ?
<

? @!
AcceptTrainingRequest

@ U
>

U V
{ 
private 
readonly 
	IEventBus "
_bus# '
;' (
private 
readonly 
ITrainerRepository +
_trainerRepo, 8
;8 9
private 
readonly &
ITrainingRequestRepository 3
_requestRepo4 @
;@ A
public (
AcceptTrainingRequestHandler +
(+ ,
	IEventBus, 5
bus6 9
,9 :
ITrainerRepository; M
trainerRepoN Y
,Y Z&
ITrainingRequestRepository[ u
requestRepo	v Å
)
Å Ç
{ 	
_bus 
= 
bus 
; 
_trainerRepo 
= 
trainerRepo &
;& '
_requestRepo 
= 
requestRepo &
;& '
} 	
public 
Task 
< 
Unit 
> 
Handle  
(  !!
AcceptTrainingRequest! 6
request7 >
,> ?
CancellationToken@ Q
cancellationTokenR c
)c d
{ 	
_trainerRepo 
. !
AcceptTrainingRequest .
(. /
request/ 6
.6 7
	RequestId7 @
)@ A
;A B
var 
requestEntity 
= 
_requestRepo  ,
., -
Get- 0
(0 1
request1 8
.8 9
	RequestId9 B
)B C
;C D
var 
user 
= 
requestEntity $
.$ %
User% )
;) *
var 
trainer 
= 
requestEntity '
.' (
Trainer( /
;/ 0
_bus   
.   
Publish   
(   
new   #
TrainingRequestAccepted   4
{!! 
TrainerEmail"" 
="" 
trainer"" &
.""& '
Email""' ,
,"", -
TrainerFirstName##  
=##! "
trainer### *
.##* +
	FirstName##+ 4
,##4 5
TrainerLastName$$ 
=$$  !
trainer$$" )
.$$) *
LastName$$* 2
,$$2 3
UserFirstName%% 
=%% 
user%%  $
.%%$ %
	FirstName%%% .
,%%. /
UserLastName&& 
=&& 
user&& #
.&&# $
LastName&&$ ,
,&&, -
UserUsername'' 
='' 
user'' #
.''# $
Username''$ ,
}(( 
)(( 
;(( 
return** 
Unit** 
.** 
Task** 
;** 
}++ 	
},, 
}-- ◊
{D:\macrotracker\MacroTracker\MacroTracker.Users.Application\UseCases\Trainers\DeactivateTrainer\DeactivateTrainerHandler.cs
	namespace 	
MacroTracker
 
. 
Users 
. 
Application (
.( )
UseCases) 1
.1 2
Trainers2 :
.: ;
DeactivateTrainer; L
{		 
public

 

class

 $
DeactivateTrainerHandler

 )
:

* +
IRequestHandler

, ;
<

; <$
DeactivateTrainerRequest

< T
>

T U
{ 
private 
readonly 
	IEventBus "
_bus# '
;' (
private 
readonly 
ITrainerRepository +
_repo, 1
;1 2
public $
DeactivateTrainerHandler '
(' (
	IEventBus( 1
bus2 5
,5 6
ITrainerRepository7 I
repoJ N
)N O
{ 	
_bus 
= 
bus 
; 
_repo 
= 
repo 
; 
} 	
public 
Task 
< 
Unit 
> 
Handle  
(  !$
DeactivateTrainerRequest! 9
request: A
,A B
CancellationTokenC T
cancellationTokenU f
)f g
{ 	
var 
trainer 
= 
_repo 
.  
Get  #
(# $
request$ +
.+ ,
	TrainerId, 5
)5 6
;6 7
if 
( 
! 
trainer 
. 
IsActive !
)! "
throw 
new (
UserAlreadyInactiveException 6
(6 7
$"7 9
User 9 >
{> ?
trainer? F
.F G
UsernameG O
}O P!
 is already inactive.P e
"e f
)f g
;g h
trainer 
. 
IsActive 
= 
false $
;$ %
_repo 
. 
Update 
( 
trainer  
)  !
;! "
_bus 
. 
Publish 
( 
new  
UserDeactivatedEvent 1
{ 
Email   
=   
trainer   
.    
Email    %
,  % &
	FirstName!! 
=!! 
trainer!! #
.!!# $
	FirstName!!$ -
,!!- .
LastName"" 
="" 
trainer"" "
.""" #
LastName""# +
}## 
)## 
;## 
return%% 
Unit%% 
.%% 
Task%% 
;%% 
}&& 	
}'' 
}(( ≥
{D:\macrotracker\MacroTracker\MacroTracker.Users.Application\UseCases\Trainers\DeactivateTrainer\DeactivateTrainerRequest.cs
	namespace 	
MacroTracker
 
. 
Users 
. 
Application (
.( )
UseCases) 1
.1 2
Trainers2 :
.: ;
DeactivateTrainer; L
{ 
public 

class $
DeactivateTrainerRequest )
:* +
IRequest, 4
{ 
public 
Guid 
	TrainerId 
{ 
get  #
;# $
set% (
;( )
}* +
}		 
}

 ù
ÖD:\macrotracker\MacroTracker\MacroTracker.Users.Application\UseCases\Trainers\DeclineTrainingRequest\DeclineTrainingRequestHandler.cs
	namespace 	
MacroTracker
 
. 
Users 
. 
Application (
.( )
UseCases) 1
.1 2
Trainers2 :
.: ;"
DeclineTrainingRequest; Q
{ 
public 

class )
DeclineTrainingRequestHandler .
:/ 0
IRequestHandler1 @
<@ A)
DeclineTrainingRequestRequestA ^
>^ _
{ 
private 
readonly &
ITrainingRequestRepository 3
_requestRepo4 @
;@ A
public )
DeclineTrainingRequestHandler ,
(, -&
ITrainingRequestRepository- G
requestRepoH S
)S T
=>U W
_requestRepoX d
=e f
requestRepog r
;r s
public 
Task 
< 
Unit 
> 
Handle  
(  !)
DeclineTrainingRequestRequest! >
request? F
,F G
CancellationTokenH Y
cancellationTokenZ k
)k l
{ 	
var 
requestEntry 
= 
_requestRepo +
.+ ,
Get, /
(/ 0
request0 7
.7 8
TrainingRequestId8 I
)I J
;J K
if 
( 
requestEntry 
== 
null  $
)$ %
throw 
new #
EntityNotFoundException 1
(1 2
request2 9
.9 :
TrainingRequestId: K
,K L
$strM _
)_ `
;` a
requestEntry 
. 
IsActive !
=" #
false$ )
;) *
_requestRepo 
. 
Update 
(  
requestEntry  ,
), -
;- .
return 
Unit 
. 
Task 
; 
} 	
}   
}!! –
ÖD:\macrotracker\MacroTracker\MacroTracker.Users.Application\UseCases\Trainers\DeclineTrainingRequest\DeclineTrainingRequestRequest.cs
	namespace 	
MacroTracker
 
. 
Users 
. 
Application (
.( )
UseCases) 1
.1 2
Trainers2 :
.: ;"
DeclineTrainingRequest; Q
{ 
public 

class )
DeclineTrainingRequestRequest .
:/ 0
IRequest1 9
{		 
public

 
Guid

 
TrainingRequestId

 %
{

& '
get

( +
;

+ ,
set

- 0
;

0 1
}

2 3
} 
} ‰ 
wD:\macrotracker\MacroTracker\MacroTracker.Users.Application\UseCases\Trainers\RegisterTrainer\RegisterTrainerHandler.cs
	namespace 	
MacroTracker
 
. 
Users 
. 
Application (
.( )
UseCases) 1
.1 2
RegisterTrainer2 A
{ 
public 

class "
RegisterTrainerHandler '
:( )
IRequestHandler* 9
<9 :"
RegisterTrainerRequest: P
>P Q
{ 
private 
readonly 
ITrainerRepository +
_repo, 1
;1 2
private 
readonly 
	IEventBus "
_bus# '
;' (
public "
RegisterTrainerHandler %
(% &
	IEventBus& /
bus0 3
,3 4
ITrainerRepository5 G
repoH L
)L M
{ 	
_bus 
= 
bus 
; 
_repo 
= 
repo 
; 
} 	
public 
Task 
< 
Unit 
> 
Handle  
(  !"
RegisterTrainerRequest! 7
request8 ?
,? @
CancellationTokenA R
cancellationTokenS d
)d e
{ 	
if 
( 
_repo 
. 
Get 
( 
u 
=> 
u  
.  !
Email! &
==' )
request* 1
.1 2
Email2 7
)7 8
.8 9
Any9 <
(< =
)= >
)> ?
throw 
new (
EntityAlreadyExistsException 6
(6 7
$"7 9
{9 :
request: A
.A B
EmailB G
}G H
 is already in use.H [
"[ \
)\ ]
;] ^
if 
( 
_repo 
. 
Get 
( 
u 
=> 
u  
.  !
Username! )
==* ,
request- 4
.4 5
Username5 =
)= >
.> ?
Any? B
(B C
)C D
)D E
throw 
new (
EntityAlreadyExistsException 6
(6 7
$"7 9
{9 :
request: A
.A B
UsernameB J
}J K
 is already in use.K ^
"^ _
)_ `
;` a
_repo!! 
.!! 
Add!! 
(!! 
new!! 
Trainer!! !
{"" 
Username## 
=## 
request## "
.##" #
Username### +
,##+ ,
Password$$ 
=$$ 
request$$ "
.$$" #
Password$$# +
,$$+ ,
Email%% 
=%% 
request%% 
.%%  
Email%%  %
,%%% &
	FirstName&& 
=&& 
request&& #
.&&# $
	FirstName&&$ -
,&&- .
LastName'' 
='' 
request'' "
.''" #
LastName''# +
,''+ ,
}(( 
)(( 
;(( 
_bus** 
.** 
Publish** 
(** 
new** 
UserRegisteredEvent** 0
(**0 1
)**1 2
{++ 
DateRegistered,, 
=,,  
DateTime,,! )
.,,) *
Now,,* -
,,,- .
Email-- 
=-- 
request-- 
.--  
Email--  %
,--% &
	FirstName.. 
=.. 
request.. #
...# $
	FirstName..$ -
,..- .
LastName// 
=// 
request// "
.//" #
LastName//# +
,//+ ,
Username00 
=00 
request00 "
.00" #
Username00# +
}11 
)11 
;11 
return22 
Unit22 
.22 
Task22 
;22 
}33 	
}44 
}55 ó
wD:\macrotracker\MacroTracker\MacroTracker.Users.Application\UseCases\Trainers\RegisterTrainer\RegisterTrainerRequest.cs
	namespace 	
MacroTracker
 
. 
Users 
. 
Application (
.( )
UseCases) 1
.1 2
RegisterTrainer2 A
{ 
public 

class "
RegisterTrainerRequest '
:( )
IRequest* 2
{ 
[ 	
Required	 
( 
ErrorMessage 
=  
$str! 8
)8 9
]9 :
[		 	
RegularExpression			 
(		 
$str		 8
,		8 9
ErrorMessage		: F
=		G H
$str		I c
)		c d
]		d e
public

 
string

 
Username

 
{

  
get

! $
;

$ %
set

& )
;

) *
}

+ ,
[ 	
Required	 
( 
ErrorMessage 
=  
$str! =
)= >
]> ?
[ 	
EmailAddress	 
( 
ErrorMessage "
=# $
$str% D
)D E
]E F
public 
string 
Email 
{ 
get !
;! "
set# &
;& '
}( )
[ 	
Required	 
( 
ErrorMessage 
=  
$str! :
): ;
]; <
[ 	
RegularExpression	 
( 
$str /
,/ 0
ErrorMessage1 =
=> ?
$str@ j
)j k
]k l
public 
string 
	FirstName 
{  !
get" %
;% &
set' *
;* +
}, -
[ 	
Required	 
] 
[ 	
RegularExpression	 
( 
$str /
)/ 0
]0 1
public 
string 
LastName 
{  
get! $
;$ %
set& )
;) *
}+ ,
[ 	
Required	 
] 
[ 	
StringLength	 
( 
maximumLength #
:# $
$num% '
,' (
MinimumLength) 6
=7 8
$num9 :
,: ;
ErrorMessage< H
=I J
$strK y
)y z
]z {
public 
string 
Password 
{  
get! $
;$ %
set& )
;) *
}+ ,
} 
} ¢"
nD:\macrotracker\MacroTracker\MacroTracker.Users.Application\UseCases\Users\RegisterUser\RegisterUserHandler.cs
	namespace 	
MacroTracker
 
. 
Users 
. 
Application (
.( )
UseCases) 1
{ 
public 

class 
RegisterUserHandler $
:% &
IRequestHandler' 6
<6 7
RegisterUserUseCase7 J
>J K
{ 
private 
readonly 
IUserRepository (
_repo) .
;. /
private 
readonly 
	IEventBus "
_bus# '
;' (
public 
RegisterUserHandler "
(" #
	IEventBus# ,
bus- 0
,0 1
IUserRepository2 A
repoB F
)F G
{ 	
_bus 
= 
bus 
; 
_repo 
= 
repo 
; 
} 	
public 
Task 
< 
Unit 
> 
Handle  
(  !
RegisterUserUseCase! 4
request5 <
,< =
CancellationToken> O
cancellationTokenP a
)a b
{ 	
if 
( 
_repo 
. 
Get 
( 
u 
=> 
u  
.  !
Email! &
.& '
ToLower' .
(. /
)/ 0
==1 3
request4 ;
.; <
Email< A
.A B
ToLowerB I
(I J
)J K
)K L
.L M
AnyM P
(P Q
)Q R
)R S
throw 
new (
EntityAlreadyExistsException 6
(6 7
$"7 9
{9 :
request: A
.A B
EmailB G
}G H
 is already in use.H [
"[ \
)\ ]
;] ^
if 
( 
_repo 
. 
Get 
( 
u 
=> 
u  
.  !
Username! )
.) *
ToLower* 1
(1 2
)2 3
==4 6
request7 >
.> ?
Username? G
.G H
ToLowerH O
(O P
)P Q
)Q R
.R S
AnyS V
(V W
)W X
)X Y
throw 
new (
EntityAlreadyExistsException 6
(6 7
$"7 9
{9 :
request: A
.A B
UsernameB J
}J K
 is already in use.K ^
"^ _
)_ `
;` a
_repo!! 
.!! 
Add!! 
(!! 
new!! 
User!! 
{"" 
Username## 
=## 
request## "
.##" #
Username### +
,##+ ,
Password$$ 
=$$ 
request$$ "
.$$" #
Password$$# +
,$$+ ,
Email%% 
=%% 
request%% 
.%%  
Email%%  %
,%%% &
	FirstName&& 
=&& 
request&& #
.&&# $
	FirstName&&$ -
,&&- .
LastName'' 
='' 
request'' "
.''" #
LastName''# +
,''+ ,
}(( 
)(( 
;(( 
_bus** 
.** 
Publish** 
(** 
new** 
UserRegisteredEvent** 0
(**0 1
)**1 2
{++ 
DateRegistered,, 
=,,  
DateTime,,! )
.,,) *
Now,,* -
,,,- .
Email-- 
=-- 
request-- 
.--  
Email--  %
,--% &
	FirstName.. 
=.. 
request.. #
...# $
	FirstName..$ -
,..- .
LastName// 
=// 
request// "
.//" #
LastName//# +
,//+ ,
Username00 
=00 
request00 "
.00" #
Username00# +
}11 
)11 
;11 
return33 
Unit33 
.33 
Task33 
;33 
}44 	
}55 
}66 ﬂ
nD:\macrotracker\MacroTracker\MacroTracker.Users.Application\UseCases\Users\RegisterUser\RegisterUserUseCase.cs
	namespace 	
MacroTracker
 
. 
Users 
. 
Application (
.( )
UseCases) 1
{ 
public 

class 
RegisterUserUseCase $
:% &
IRequest' /
{ 
[ 	
Required	 
( 
ErrorMessage 
=  
$str! 8
)8 9
]9 :
[		 	
RegularExpression			 
(		 
$str		 8
,		8 9
ErrorMessage		: F
=		G H
$str		I c
)		c d
]		d e
public

 
string

 
Username

 
{

  
get

! $
;

$ %
set

& )
;

) *
}

+ ,
[ 	
Required	 
( 
ErrorMessage 
=  
$str! =
)= >
]> ?
[ 	
EmailAddress	 
( 
ErrorMessage "
=# $
$str% D
)D E
]E F
public 
string 
Email 
{ 
get !
;! "
set# &
;& '
}( )
[ 	
Required	 
( 
ErrorMessage 
=  
$str! :
): ;
]; <
[ 	
RegularExpression	 
( 
$str /
,/ 0
ErrorMessage1 =
=> ?
$str@ j
)j k
]k l
public 
string 
	FirstName 
{  !
get" %
;% &
set' *
;* +
}, -
[ 	
Required	 
] 
[ 	
RegularExpression	 
( 
$str /
)/ 0
]0 1
public 
string 
LastName 
{  
get! $
;$ %
set& )
;) *
}+ ,
[ 	
Required	 
] 
[ 	
StringLength	 
( 
maximumLength #
:# $
$num% '
,' (
MinimumLength) 6
=7 8
$num9 :
,: ;
ErrorMessage< H
=I J
$strK y
)y z
]z {
public 
string 
Password 
{  
get! $
;$ %
set& )
;) *
}+ ,
} 
} ô
kD:\macrotracker\MacroTracker\MacroTracker.Users.Application\UseCases\Users\SearchUsers\SearchUserHandler.cs
	namespace 	
MacroTracker
 
. 
Users 
. 
Application (
.( )
UseCases) 1
.1 2
SearchUsers2 =
{		 
public

 

class

 
SearchUserHandler

 "
:

# $
IRequestHandler

% 4
<

4 5
SearchUsersRequest

5 G
,

G H
IEnumerable

I T
<

T U
UserDto

U \
>

\ ]
>

] ^
{ 
private 
readonly 
IUserRepository (
_repo) .
;. /
public 
SearchUserHandler  
(  !
IUserRepository! 0
repo1 5
)5 6
=>7 9
_repo: ?
=@ A
repoB F
;F G
public 
Task 
< 
IEnumerable 
<  
UserDto  '
>' (
>( )
Handle* 0
(0 1
SearchUsersRequest1 C
requestD K
,K L
CancellationTokenM ^
cancellationToken_ p
)p q
{ 	
var 
result 
= 
request  
.  !
Keyword! (
==) +
null, 0
? 
_repo 
. 
Get 
( 
u 
=>  
u! "
." #
IsActive# +
,+ ,
request- 4
.4 5
PerPage5 <
,< =
request> E
.E F

PageNumberF P
)P Q
: 
_repo 
. 
Get 
( 
u 
=> 
u 
. 
IsActive #
&&$ &
( 
u 
. 
	FirstName $
.$ %
ToLower% ,
(, -
)- .
.. /
Contains/ 7
(7 8
request8 ?
.? @
Keyword@ G
.G H
ToLowerH O
(O P
)P Q
)Q R
||S U
u 
. 
LastName #
.# $
ToLower$ +
(+ ,
), -
.- .
Contains. 6
(6 7
request7 >
.> ?
Keyword? F
.F G
ToLowerG N
(N O
)O P
)P Q
)Q R
,R S
request 
. 
PerPage #
,# $
request 
. 

PageNumber &
)& '
;' (
return 
Task 
. 

FromResult "
(" #
result# )
.) *
Select* 0
(0 1
u1 2
=>3 5
new6 9
UserDto: A
{ 
Email 
= 
u 
. 
Email 
,  
	FirstName 
= 
u 
. 
	FirstName '
,' (
LastName 
= 
u 
. 
LastName %
,% &
Id   
=   
u   
.   
Id   
}!! 
)!! 
)!! 
;!! 
}"" 	
}## 
}$$ 
lD:\macrotracker\MacroTracker\MacroTracker.Users.Application\UseCases\Users\SearchUsers\SearchUsersRequest.cs
	namespace 	
MacroTracker
 
. 
Users 
. 
Application (
.( )
UseCases) 1
.1 2
SearchUsers2 =
{ 
public 

class 
SearchUsersRequest #
:$ %
IRequest& .
<. /
IEnumerable/ :
<: ;
UserDto; B
>B C
>C D
{ 
public 
string 
Keyword 
{ 
get  #
;# $
set% (
;( )
}* +
public		 
int		 

PageNumber		 
{		 
get		  #
;		# $
set		% (
;		( )
}		* +
=		, -
$num		. /
;		/ 0
public

 
int

 
PerPage

 
{

 
get

  
;

  !
set

" %
;

% &
}

' (
=

) *
$num

+ -
;

- .
} 
} É
aD:\macrotracker\MacroTracker\MacroTracker.Users.Application\UseCases\Users\SearchUsers\UserDto.cs
	namespace 	
MacroTracker
 
. 
Users 
. 
Application (
.( )
UseCases) 1
.1 2
SearchUsers2 =
{ 
public 

class 
UserDto 
{ 
public 
string 
	FirstName 
{  !
get" %
;% &
set' *
;* +
}, -
public 
string 
LastName 
{  
get! $
;$ %
set& )
;) *
}+ ,
public		 
string		 
Email		 
{		 
get		 !
;		! "
set		# &
;		& '
}		( )
public

 
Guid

 
Id

 
{

 
get

 
;

 
set

 !
;

! "
}

# $
} 
} ò(
|D:\macrotracker\MacroTracker\MacroTracker.Users.Application\UseCases\Users\SendTrainingRequest\SendTrainingRequestHandler.cs
	namespace 	
MacroTracker
 
. 
Users 
. 
Application (
.( )
UseCases) 1
.1 2
Users2 7
.7 8
SendTrainingRequest8 K
{ 
public 

class &
SendTrainingRequestHandler +
:, -
IRequestHandler. =
<= >&
SendTrainingRequestRequest> X
>X Y
{ 
private 
readonly 
IUserRepository (
	_userRepo) 2
;2 3
private 
readonly 
ITrainerRepository +
_trainerRepo, 8
;8 9
private 
readonly &
ITrainingRequestRepository 3
_requestRepo4 @
;@ A
private 
readonly 
	IEventBus "
	_eventBus# ,
;, -
public &
SendTrainingRequestHandler )
() *
IUserRepository* 9
userRepo: B
,B C
ITrainerRepositoryD V
trainerRepoW b
,b c&
ITrainingRequestRepositoryd ~
requestRepo	 ä
,
ä ã
	IEventBus
å ï
eventBus
ñ û
)
û ü
{ 	
	_userRepo 
= 
userRepo  
;  !
_trainerRepo 
= 
trainerRepo &
;& '
_requestRepo 
= 
requestRepo &
;& '
	_eventBus 
= 
eventBus  
;  !
} 	
public 
Task 
< 
Unit 
> 
Handle  
(  !&
SendTrainingRequestRequest! ;
request< C
,C D
CancellationTokenE V
cancellationTokenW h
)h i
{ 	
var 
user 
= 
	_userRepo  
.  !
Get! $
($ %
request% ,
., -
UserId- 3
)3 4
;4 5
if 
( 
user 
== 
null 
) 
throw   
new   #
EntityNotFoundException   1
(  1 2
request  2 9
.  9 :
UserId  : @
,  @ A
$str  B H
)  H I
;  I J
var"" 
trainer"" 
="" 
_trainerRepo"" &
.""& '
Get""' *
(""* +
request""+ 2
.""2 3
	TrainerId""3 <
)""< =
;""= >
if## 
(## 
trainer## 
==## 
null## 
)##  
throw$$ 
new$$ #
EntityNotFoundException$$ 1
($$1 2
request$$2 9
.$$9 :
	TrainerId$$: C
,$$C D
$str$$E N
)$$N O
;$$O P
if&& 
(&& 
_requestRepo&& 
.&& 
Get&&  
(&&  !
r&&! "
=>&&# %
r&&& '
.&&' (
	TrainerId&&( 1
==&&2 4
request&&5 <
.&&< =
	TrainerId&&= F
&&&&G I
r&&J K
.&&K L
UserId&&L R
==&&S U
request&&V ]
.&&] ^
UserId&&^ d
&&&&e g
r&&h i
.&&i j
IsActive&&j r
)&&r s
.&&s t
Any&&t w
(&&w x
)&&x y
)&&y z
throw'' 
new'' (
EntityAlreadyExistsException'' 6
(''6 7
$str	''7 É
)
''É Ñ
;
''Ñ Ö
_requestRepo)) 
.)) 
Add)) 
()) 
new))  
TrainingRequest))! 0
{** 
	TrainerId++ 
=++ 
request++ #
.++# $
	TrainerId++$ -
,++- .
UserId,, 
=,, 
request,,  
.,,  !
UserId,,! '
}-- 
)-- 
;-- 
	_eventBus// 
.// 
Publish// 
(// 
new// !#
TrainingRequestRecieved//" 9
{00 
TrainerEmail11 
=11 
trainer11 &
.11& '
Email11' ,
,11, -
TrainerFirstName22  
=22! "
trainer22# *
.22* +
	FirstName22+ 4
,224 5
TrainerLastName33 
=33  !
trainer33" )
.33) *
LastName33* 2
,332 3
UserFirstName44 
=44 
user44  $
.44$ %
	FirstName44% .
,44. /
UserLastName55 
=55 
user55 #
.55# $
LastName55$ ,
,55, -
UserUsername66 
=66 
user66 #
.66# $
Username66$ ,
}77 
)77 
;77 
return99 
Unit99 
.99 
Task99 
;99 
}:: 	
};; 
}<< Õ
|D:\macrotracker\MacroTracker\MacroTracker.Users.Application\UseCases\Users\SendTrainingRequest\SendTrainingRequestRequest.cs
	namespace 	
MacroTracker
 
. 
Users 
. 
Application (
.( )
UseCases) 1
.1 2
Users2 7
.7 8
SendTrainingRequest8 K
{ 
public 

class &
SendTrainingRequestRequest +
:, -
IRequest. 6
{ 
public 
Guid 
	TrainerId 
{ 
get  #
;# $
set% (
;( )
}* +
public		 
Guid		 
UserId		 
{		 
get		  
;		  !
set		" %
;		% &
}		' (
}

 
} √
qD:\macrotracker\MacroTracker\MacroTracker.Users.Application\UseCases\Users\UpdateUserUseCase\UpdateUserHandler.cs
	namespace 	
MacroTracker
 
. 
Users 
. 
Application (
.( )
UseCases) 1
.1 2
Users2 7
.7 8
UpdateUserUseCase8 I
{ 
public		 

class		 
UpdateUserHandler		 "
:		# $
IRequestHandler		% 4
<		4 5
UpdateUserRequest		5 F
>		F G
{

 
private 
readonly 
IUserRepository (
_repo) .
;. /
public 
UpdateUserHandler  
(  !
IUserRepository! 0
repo1 5
)5 6
{ 	
_repo 
= 
repo 
; 
} 	
public 
Task 
< 
Unit 
> 
Handle  
(  !
UpdateUserRequest! 2
request3 :
,: ;
CancellationToken< M
cancellationTokenN _
)_ `
{ 	
var 
user 
= 
_repo 
. 
Get  
(  !
request! (
.( )
UserId) /
)/ 0
;0 1
if 
( 
! 
user 
. 
IsActive 
) 
throw 
new #
EntityNotFoundException 1
(1 2
user2 6
.6 7
Id7 9
,9 :
$str; A
)A B
;B C
user 
. 
Email 
= 
request  
.  !
Email! &
;& '
user 
. 
	FirstName 
= 
request $
.$ %
	FirstName% .
;. /
user 
. 
LastName 
= 
request #
.# $
LastName$ ,
;, -
user 
. 
Username 
= 
request #
.# $
Username$ ,
;, -
_repo 
. 
Update 
( 
user 
) 
; 
return 
Unit 
. 
Task 
; 
}   	
}!! 
}"" £
qD:\macrotracker\MacroTracker\MacroTracker.Users.Application\UseCases\Users\UpdateUserUseCase\UpdateUserRequest.cs
	namespace 	
MacroTracker
 
. 
Users 
. 
Application (
.( )
UseCases) 1
.1 2
Users2 7
{ 
public 

class 
UpdateUserRequest "
:# $
IRequest% -
{ 
[		 	
Required			 
(		 
ErrorMessage		 
=		  
$str		! 8
)		8 9
]		9 :
[

 	
RegularExpression

	 
(

 
$str

 8
,

8 9
ErrorMessage

: F
=

G H
$str

I c
)

c d
]

d e
public 
string 
Username 
{  
get! $
;$ %
set& )
;) *
}+ ,
[ 	
Required	 
( 
ErrorMessage 
=  
$str! =
)= >
]> ?
[ 	
EmailAddress	 
( 
ErrorMessage "
=# $
$str% D
)D E
]E F
public 
string 
Email 
{ 
get !
;! "
set# &
;& '
}( )
[ 	
Required	 
( 
ErrorMessage 
=  
$str! :
): ;
]; <
[ 	
RegularExpression	 
( 
$str /
,/ 0
ErrorMessage1 =
=> ?
$str@ j
)j k
]k l
public 
string 
	FirstName 
{  !
get" %
;% &
set' *
;* +
}, -
[ 	
Required	 
] 
[ 	
RegularExpression	 
( 
$str /
)/ 0
]0 1
public 
string 
LastName 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
Guid 
UserId 
{ 
get  
;  !
set" %
;% &
}' (
} 
} 