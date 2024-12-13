call speak('A', c='C', *['B'], **{'d': 'D', 'f': 'F'}, e='E')

label speak(a, b, c, d, e, **kwargs):
	"[a] [b] [c] [d] [e] [kwargs.f]"
	return
