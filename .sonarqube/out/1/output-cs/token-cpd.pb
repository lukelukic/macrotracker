�
AD:\macrotracker\MacroTracker\EventBusRabbitMQ\RabbitMQEventBus.cs
	namespace 	
EventBusRabbitMQ
 
{ 
public 

class 
RabbitMQEventBus !
:" #
EventBus$ ,
., -
	IEventBus- 6
{ 
private		 
readonly		 
IBus		 
_bus		 "
;		" #
public 
RabbitMQEventBus 
(  
string  &
host' +
,+ ,
string- 3
username4 <
,< =
string> D
passwordE M
)M N
{ 	
_bus
=
RabbitHutch
.
	CreateBus
(
$"
host=
{
host
}

;username=
{
username
}

;password=
{
password
}
"
)
;
} 	
public 
void 
Publish 
< 
TEvent "
>" #
(# $
TEvent$ *
@event+ 1
)1 2
where3 8
TEvent9 ?
:@ A
classB G
,G H
IEventI O
=> 
_bus 
. 
Publish 
( 
@event "
)" #
;# $
public 
void 
	Subscribe 
< 
TEvent $
>$ %
(% &
string& ,
	queueName- 6
,6 7
Action8 >
<> ?
TEvent? E
>E F
eventHandlerG S
)S T
whereU Z
TEvent[ a
:b c
classd i
,i j
IEventk q
=> 
_bus 
. 
	Subscribe 
( 
	queueName '
,' (
eventHandler) 5
)5 6
;6 7
} 
} 