ì
LD:\macrotracker\MacroTracker\MacroTracker.Users.Domain\Concepts\RoleTypes.cs
	namespace 	
MacroTracker
 
. 
Users 
. 
Domain #
.# $
Concepts$ ,
{ 
public 

static 
class 
	RoleTypes !
{ 
public 
const 
string 
Admin !
=" #
$str$ +
;+ ,
public 
const 
string 
User  
=! "
$str# )
;) *
public 
const 
string 
Trainer #
=$ %
$str& /
;/ 0
} 
}		 ´
ID:\macrotracker\MacroTracker\MacroTracker.Users.Domain\Entities\Entity.cs
	namespace 	
MacroTracker
 
. 
Users 
. 
Domain #
{ 
public 

abstract 
class 
Entity  
{ 
public 
Guid 
Id 
{ 
get 
; 
set !
;! "
}# $
public 
DateTime 
	CreatedAt !
{" #
get$ '
;' (
set) ,
;, -
}. /
public		 
DateTime		 
	UpdatedAt		 !
{		" #
get		$ '
;		' (
set		) ,
;		, -
}		. /
public

 
bool

 
IsActive

 
{

 
get

 "
;

" #
set

$ '
;

' (
}

) *
} 
} ä
JD:\macrotracker\MacroTracker\MacroTracker.Users.Domain\Entities\Trainer.cs
	namespace 	
MacroTracker
 
. 
Users 
. 
Domain #
.# $
Entities$ ,
{ 
public 

class 
Trainer 
: 
User 
{ 
public 
virtual 
ICollection "
<" #
TrainerUser# .
>. /
TrainerUsers0 <
{= >
get? B
;B C
setD G
;G H
}I J
public 
virtual 
ICollection "
<" #
TrainingRequest# 2
>2 3
RecievedRequests4 D
{E F
getG J
;J K
setL O
;O P
}Q R
}		 
}

 Ë
ND:\macrotracker\MacroTracker\MacroTracker.Users.Domain\Entities\TrainerUser.cs
	namespace 	
MacroTracker
 
. 
Users 
. 
Domain #
{ 
public 

class 
TrainerUser 
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
}		' (
public 
virtual 
Trainer 
Trainer &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
public 
virtual 
User 
User  
{! "
get# &
;& '
set( +
;+ ,
}- .
} 
} ›
RD:\macrotracker\MacroTracker\MacroTracker.Users.Domain\Entities\TrainingRequest.cs
	namespace 	
MacroTracker
 
. 
Users 
. 
Domain #
.# $
Entities$ ,
{ 
public 

class 
TrainingRequest  
:! "
Entity# )
{ 
public 
Guid 
	TrainerId 
{ 
get  #
;# $
set% (
;( )
}* +
public 
Guid 
UserId 
{ 
get  
;  !
set" %
;% &
}' (
public

 
virtual

 
User

 
User

  
{

! "
get

# &
;

& '
set

( +
;

+ ,
}

- .
public 
virtual 
Trainer 
Trainer &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
} 
} Á
GD:\macrotracker\MacroTracker\MacroTracker.Users.Domain\Entities\User.cs
	namespace 	
MacroTracker
 
. 
Users 
. 
Domain #
{ 
public 

class 
User 
: 
Entity 
{ 
public 
string 
	FirstName 
{  !
get" %
;% &
set' *
;* +
}, -
public		 
string		 
LastName		 
{		  
get		! $
;		$ %
set		& )
;		) *
}		+ ,
public

 
string

 
Email

 
{

 
get

 !
;

! "
set

# &
;

& '
}

( )
public 
string 
Password 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
string 
Username 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
virtual 
ICollection "
<" #
TrainerUser# .
>. /
UserTrainers0 <
{= >
get? B
;B C
setD G
;G H
}I J
public 
virtual 
ICollection "
<" #
TrainingRequest# 2
>2 3
SentRequests4 @
{A B
getC F
;F G
setH K
;K L
}M N
} 
} 