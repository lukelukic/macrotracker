Ò
ID:\macrotracker\MacroTracker\EventTypes\Events\TrainingRequestAccepted.cs
	namespace 	
EventBus
 
. 
Events 
{ 
public 

class #
TrainingRequestAccepted (
:) *$
TrainingRequestBaseEvent+ C
{ 
}

 
}  

JD:\macrotracker\MacroTracker\EventTypes\Events\TrainingRequestBaseEvent.cs
	namespace 	
EventBus
 
. 
Events 
{ 
public 

abstract 
class $
TrainingRequestBaseEvent 2
:3 4
IEvent5 ;
{ 
public		 
string		 
TrainerEmail		 "
{		# $
get		% (
;		( )
set		* -
;		- .
}		/ 0
public

 
string

 
TrainerFirstName

 &
{

' (
get

) ,
;

, -
set

. 1
;

1 2
}

3 4
public 
string 
TrainerLastName %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
public 
string 
UserUsername "
{# $
get% (
;( )
set* -
;- .
}/ 0
public 
string 
UserFirstName #
{$ %
get& )
;) *
set+ .
;. /
}0 1
public 
string 
UserLastName "
{# $
get% (
;( )
set* -
;- .
}/ 0
} 
} Ò
ID:\macrotracker\MacroTracker\EventTypes\Events\TrainingRequestReceived.cs
	namespace 	
EventBus
 
. 
Events 
{ 
public 

class #
TrainingRequestRecieved (
:) *$
TrainingRequestBaseEvent+ C
{ 
} 
} Œ
FD:\macrotracker\MacroTracker\EventTypes\Events\UserDeactivatedEvent.cs
	namespace 	
EventBus
 
. 
Events 
{ 
public 

class  
UserDeactivatedEvent %
:& '
IEvent( .
{ 
public 
string 
	FirstName 
{  !
get" %
;% &
set' *
;* +
}, -
public 
string 
LastName 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
string 
Email 
{ 
get !
;! "
set# &
;& '
}( )
} 
}		 Ê
ED:\macrotracker\MacroTracker\EventTypes\Events\UserRegisteredEvent.cs
	namespace 	
EventBus
 
. 
Events 
{ 
public 

class 
UserRegisteredEvent $
:% &
IEvent' -
{ 
public 
string 
Username 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
string 
Email 
{ 
get !
;! "
set# &
;& '
}( )
public		 
string		 
	FirstName		 
{		  !
get		" %
;		% &
set		' *
;		* +
}		, -
public

 
string

 
LastName
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
+ ,
public 
DateTime 
DateRegistered &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
} 
} Õ
1D:\macrotracker\MacroTracker\EventTypes\IEvent.cs
	namespace 	
EventBus
 
{ 
public 

	interface 
IEvent 
{ 
} 
} ƒ
4D:\macrotracker\MacroTracker\EventTypes\IEventBus.cs
	namespace 	
EventBus
 
{ 
public 

	interface 
	IEventBus 
{ 
void 
	Subscribe 
< 
TEvent 
> 
( 
string %
	queueName& /
,/ 0
Action1 7
<7 8
TEvent8 >
>> ?
eventHandler@ L
)L M
whereN S
TEventT Z
:[ \
class] b
,b c
IEventd j
;j k
void		 
Publish		 
<		 
TEvent		 
>		 
(		 
TEvent		 #
@event		$ *
)		* +
where		, 1
TEvent		2 8
:		9 :
class		; @
,		@ A
IEvent		B H
;		H I
}

 
} 