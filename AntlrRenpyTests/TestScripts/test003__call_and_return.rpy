jump skipMyLabel

label myLabel:
	pass
	return

label skipMyLabel
pass
call myLabel
pass
