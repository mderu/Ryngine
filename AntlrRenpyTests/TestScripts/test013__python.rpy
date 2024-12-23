define eileen = Character("Eileen")

label start:

    python:
        my_menuset = ["Hey, this wasn't here before. What gives?"]
        questions_asked =  0

    menu question_menu:
        set my_menuset
        eileen "Do you have any questions?"
        
        "What do menu sets do?":
            $ questions_asked += 1
            eileen "In short, they prevent options from appearing."
            jump question_menu

        "Do I need to manually add elements to the menu set?":
            $ questions_asked += 1
            eileen "Options are automatically added to the set after being selected."
            eileen "The next time you visit a menu the option will go away. No need to manually add items."
            jump question_menu

        "Hey, this wasn't here before. What gives?":
            $ questions_asked += 1
            eileen "This option was in the set initially. Now that you've cleared the questions, it is present once again."
            jump question_menu

        "I'm confused. Let me try re-asking my questions.":
            eileen "Sure, all you need to do is clear the set and jump back to the menu!"
            $ my_menuset.clear()
            jump question_menu

        "No, let's move on.":
            pass

    if questions_asked == 0:
        eileen "Glad you already understand the basics!"

    else:
        eileen "Glad I could help. Let's move on!"
