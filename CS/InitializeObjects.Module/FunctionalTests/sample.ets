;#DropDB InitializeObjectsEasyTest

#Application InitializeObjects.Win
#Application InitializeObjects.Web
#IfDef InitializeObjects.Win

*Action About...
 
*Action OK

#EndIf

#IfDef InitializeObjects.Web

*Action Choose Theme(Black Glass)

#EndIf
