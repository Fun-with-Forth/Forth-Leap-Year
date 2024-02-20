\ Fun with Forth
\ LeapYear.fs

\ n IsLeapYear? - Returns True or False on the stack

\ January 2024


: isDivBy1000 1000 mod 0 = ;
: isDivBy400 400 mod 0 = ;
: isDivBy4 4 mod 0 = ;
: isDivBy1000and400 ( n -- -1 if divisible by 1000 and divisible by 400, else 0 ) dup isDivBy1000 swap isDivBy400 AND ;

( Leap Year definition -- reading / as "divisible by" )
( / 4 and not / 1000 or / 1000 and  / 400 )
: isLeapYear? ( n -- TRUE if leap year else FALSE )
  DUP DUP
  isDivBy1000and400 
  if            ( we know it's a Leap Year because it isDivBy1000and400 )   
    2DROP       ( drop the remaining items from the stack )
    TRUE        ( return true )
  else
    isDivBy1000  
    if drop     \  ( we know it's not a Leap Year because it isDivBy1000 (and must not be div by 400) )
      FALSE     ( return false on the stack )
    else
      isDivBy4  ( return result of isdivby4 )
    then 
  then
;