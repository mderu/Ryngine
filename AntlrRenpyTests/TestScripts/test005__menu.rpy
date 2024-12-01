"Full documentation can be found here: https://www.renpy.org/doc/html/menus.html#menu-set"
"Set clauses and if statements are not covered by this test."

menu:
	Narrator "There's a single optional say statement here."
	"This is a menu choice, it ends in a colon. Menu must contain at least one menu choice":
		"Menu choices must be followed by a block of Ren'Py statements."

	"When the choice is selected, the block of statements is run":
		"If execution reaches the end of the block ..."
		"it continues with the statement after the end of the menu statement."
		"In other words, selecting the first choice won't show messages from this choice."

"This instruction is then jumped to."
"A test where the menu is the last item may also be helpful to have around."