//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.13.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from c:/Users/markd/Documents/GitHub/Ryngine/AntlrRenpy/Parser/RenpyLexer.g4 by ANTLR 4.13.1

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using System;
using System.IO;
using System.Text;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.13.1")]
[System.CLSCompliant(false)]
public partial class RenpyLexer : RenpyLexerBase {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		INDENT=1, DEDENT=2, LABEL=3, JUMP=4, CALL=5, PASS=6, RETURN=7, WITH=8, 
		MENU=9, TRUE=10, FALSE=11, NONE=12, LPAR=13, LSQB=14, LBRACE=15, RPAR=16, 
		RSQB=17, RBRACE=18, PLUS=19, MINUS=20, DOT=21, COLON=22, EQUALS=23, COMMA=24, 
		STAR=25, DOUBLESTAR=26, COLONEQUAL=27, NAME=28, STRING=29, NUMBER=30, 
		NEWLINE=31, COMMENT=32, WS=33, EXPLICIT_LINE_JOINING=34, ERRORTOKEN=35;
	public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"LABEL", "JUMP", "CALL", "PASS", "RETURN", "WITH", "MENU", "TRUE", "FALSE", 
		"NONE", "LPAR", "LSQB", "LBRACE", "RPAR", "RSQB", "RBRACE", "PLUS", "MINUS", 
		"DOT", "COLON", "EQUALS", "COMMA", "STAR", "DOUBLESTAR", "COLONEQUAL", 
		"NAME", "STRING", "NUMBER", "INTEGER", "DEC_INTEGER", "BIN_INTEGER", "OCT_INTEGER", 
		"HEX_INTEGER", "NON_ZERO_DIGIT", "DIGIT", "BIN_DIGIT", "OCT_DIGIT", "HEX_DIGIT", 
		"FLOAT_NUMBER", "POINT_FLOAT", "EXPONENT_FLOAT", "DIGIT_PART", "FRACTION", 
		"EXPONENT", "NEWLINE", "COMMENT", "WS", "EXPLICIT_LINE_JOINING", "ERRORTOKEN", 
		"SHORT_STRING", "SHORT_STRING_ITEM_FOR_SINGLE_QUOTE", "SHORT_STRING_ITEM_FOR_DOUBLE_QUOTE", 
		"SHORT_STRING_CHAR_NO_SINGLE_QUOTE", "SHORT_STRING_CHAR_NO_DOUBLE_QUOTE", 
		"LONG_STRING", "LONG_STRING_ITEM", "LONG_STRING_CHAR", "STRING_ESCAPE_SEQ", 
		"ID_CONTINUE", "ID_START"
	};


	public RenpyLexer(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public RenpyLexer(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	private static readonly string[] _LiteralNames = {
		null, null, null, "'label'", "'jump'", "'call'", "'pass'", "'return'", 
		"'with'", "'menu'", "'True'", "'False'", "'None'", "'('", "'['", "'{'", 
		"')'", "']'", "'}'", "'+'", "'-'", "'.'", "':'", "'='", "','", "'*'", 
		"'**'", "':='"
	};
	private static readonly string[] _SymbolicNames = {
		null, "INDENT", "DEDENT", "LABEL", "JUMP", "CALL", "PASS", "RETURN", "WITH", 
		"MENU", "TRUE", "FALSE", "NONE", "LPAR", "LSQB", "LBRACE", "RPAR", "RSQB", 
		"RBRACE", "PLUS", "MINUS", "DOT", "COLON", "EQUALS", "COMMA", "STAR", 
		"DOUBLESTAR", "COLONEQUAL", "NAME", "STRING", "NUMBER", "NEWLINE", "COMMENT", 
		"WS", "EXPLICIT_LINE_JOINING", "ERRORTOKEN"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "RenpyLexer.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ChannelNames { get { return channelNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override int[] SerializedAtn { get { return _serializedATN; } }

	static RenpyLexer() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}
	private static int[] _serializedATN = {
		4,0,35,439,6,-1,2,0,7,0,2,1,7,1,2,2,7,2,2,3,7,3,2,4,7,4,2,5,7,5,2,6,7,
		6,2,7,7,7,2,8,7,8,2,9,7,9,2,10,7,10,2,11,7,11,2,12,7,12,2,13,7,13,2,14,
		7,14,2,15,7,15,2,16,7,16,2,17,7,17,2,18,7,18,2,19,7,19,2,20,7,20,2,21,
		7,21,2,22,7,22,2,23,7,23,2,24,7,24,2,25,7,25,2,26,7,26,2,27,7,27,2,28,
		7,28,2,29,7,29,2,30,7,30,2,31,7,31,2,32,7,32,2,33,7,33,2,34,7,34,2,35,
		7,35,2,36,7,36,2,37,7,37,2,38,7,38,2,39,7,39,2,40,7,40,2,41,7,41,2,42,
		7,42,2,43,7,43,2,44,7,44,2,45,7,45,2,46,7,46,2,47,7,47,2,48,7,48,2,49,
		7,49,2,50,7,50,2,51,7,51,2,52,7,52,2,53,7,53,2,54,7,54,2,55,7,55,2,56,
		7,56,2,57,7,57,2,58,7,58,2,59,7,59,1,0,1,0,1,0,1,0,1,0,1,0,1,1,1,1,1,1,
		1,1,1,1,1,2,1,2,1,2,1,2,1,2,1,3,1,3,1,3,1,3,1,3,1,4,1,4,1,4,1,4,1,4,1,
		4,1,4,1,5,1,5,1,5,1,5,1,5,1,6,1,6,1,6,1,6,1,6,1,7,1,7,1,7,1,7,1,7,1,8,
		1,8,1,8,1,8,1,8,1,8,1,9,1,9,1,9,1,9,1,9,1,10,1,10,1,11,1,11,1,12,1,12,
		1,13,1,13,1,14,1,14,1,15,1,15,1,16,1,16,1,17,1,17,1,18,1,18,1,19,1,19,
		1,20,1,20,1,21,1,21,1,22,1,22,1,23,1,23,1,23,1,24,1,24,1,24,1,25,1,25,
		5,25,210,8,25,10,25,12,25,213,9,25,1,26,1,26,3,26,217,8,26,1,27,1,27,3,
		27,221,8,27,1,28,1,28,1,28,1,28,3,28,227,8,28,1,29,1,29,3,29,231,8,29,
		1,29,5,29,234,8,29,10,29,12,29,237,9,29,1,29,4,29,240,8,29,11,29,12,29,
		241,1,29,3,29,245,8,29,1,29,5,29,248,8,29,10,29,12,29,251,9,29,3,29,253,
		8,29,1,30,1,30,1,30,3,30,258,8,30,1,30,4,30,261,8,30,11,30,12,30,262,1,
		31,1,31,1,31,3,31,268,8,31,1,31,4,31,271,8,31,11,31,12,31,272,1,32,1,32,
		1,32,3,32,278,8,32,1,32,4,32,281,8,32,11,32,12,32,282,1,33,1,33,1,34,1,
		34,1,35,1,35,1,36,1,36,1,37,1,37,3,37,295,8,37,1,38,1,38,3,38,299,8,38,
		1,39,3,39,302,8,39,1,39,1,39,1,39,1,39,3,39,308,8,39,1,40,1,40,3,40,312,
		8,40,1,40,1,40,1,41,1,41,3,41,318,8,41,1,41,5,41,321,8,41,10,41,12,41,
		324,9,41,1,42,1,42,1,42,1,43,1,43,3,43,331,8,43,1,43,1,43,1,44,3,44,336,
		8,44,1,44,1,44,1,45,1,45,5,45,342,8,45,10,45,12,45,345,9,45,1,45,1,45,
		1,46,4,46,350,8,46,11,46,12,46,351,1,46,1,46,1,47,1,47,1,47,1,47,1,47,
		1,48,1,48,1,49,1,49,5,49,365,8,49,10,49,12,49,368,9,49,1,49,1,49,1,49,
		5,49,373,8,49,10,49,12,49,376,9,49,1,49,3,49,379,8,49,1,50,1,50,3,50,383,
		8,50,1,51,1,51,3,51,387,8,51,1,52,1,52,1,53,1,53,1,54,1,54,1,54,1,54,1,
		54,5,54,398,8,54,10,54,12,54,401,9,54,1,54,1,54,1,54,1,54,1,54,1,54,1,
		54,1,54,5,54,411,8,54,10,54,12,54,414,9,54,1,54,1,54,1,54,3,54,419,8,54,
		1,55,1,55,3,55,423,8,55,1,56,1,56,1,57,1,57,1,57,1,57,1,57,3,57,432,8,
		57,1,58,1,58,3,58,436,8,58,1,59,1,59,2,399,412,0,60,1,3,3,4,5,5,7,6,9,
		7,11,8,13,9,15,10,17,11,19,12,21,13,23,14,25,15,27,16,29,17,31,18,33,19,
		35,20,37,21,39,22,41,23,43,24,45,25,47,26,49,27,51,28,53,29,55,30,57,0,
		59,0,61,0,63,0,65,0,67,0,69,0,71,0,73,0,75,0,77,0,79,0,81,0,83,0,85,0,
		87,0,89,31,91,32,93,33,95,34,97,35,99,0,101,0,103,0,105,0,107,0,109,0,
		111,0,113,0,115,0,117,0,119,0,1,0,16,2,0,66,66,98,98,2,0,79,79,111,111,
		2,0,88,88,120,120,1,0,49,57,1,0,48,57,1,0,48,55,2,0,65,70,97,102,2,0,69,
		69,101,101,2,0,43,43,45,45,2,0,10,10,13,13,3,0,9,9,12,12,32,32,2,0,39,
		39,92,92,2,0,34,34,92,92,1,0,92,92,374,0,48,57,183,183,768,879,903,903,
		1155,1159,1425,1469,1471,1471,1473,1474,1476,1477,1479,1479,1552,1562,
		1611,1641,1648,1648,1750,1756,1759,1764,1767,1768,1770,1773,1776,1785,
		1809,1809,1840,1866,1958,1968,1984,1993,2027,2035,2045,2045,2070,2073,
		2075,2083,2085,2087,2089,2093,2137,2139,2200,2207,2250,2273,2275,2307,
		2362,2364,2366,2383,2385,2391,2402,2403,2406,2415,2433,2435,2492,2492,
		2494,2500,2503,2504,2507,2509,2519,2519,2530,2531,2534,2543,2558,2558,
		2561,2563,2620,2620,2622,2626,2631,2632,2635,2637,2641,2641,2662,2673,
		2677,2677,2689,2691,2748,2748,2750,2757,2759,2761,2763,2765,2786,2787,
		2790,2799,2810,2815,2817,2819,2876,2876,2878,2884,2887,2888,2891,2893,
		2901,2903,2914,2915,2918,2927,2946,2946,3006,3010,3014,3016,3018,3021,
		3031,3031,3046,3055,3072,3076,3132,3132,3134,3140,3142,3144,3146,3149,
		3157,3158,3170,3171,3174,3183,3201,3203,3260,3260,3262,3268,3270,3272,
		3274,3277,3285,3286,3298,3299,3302,3311,3315,3315,3328,3331,3387,3388,
		3390,3396,3398,3400,3402,3405,3415,3415,3426,3427,3430,3439,3457,3459,
		3530,3530,3535,3540,3542,3542,3544,3551,3558,3567,3570,3571,3633,3633,
		3635,3642,3655,3662,3664,3673,3761,3761,3763,3772,3784,3790,3792,3801,
		3864,3865,3872,3881,3893,3893,3895,3895,3897,3897,3902,3903,3953,3972,
		3974,3975,3981,3991,3993,4028,4038,4038,4139,4158,4160,4169,4182,4185,
		4190,4192,4194,4196,4199,4205,4209,4212,4226,4237,4239,4253,4957,4959,
		4969,4977,5906,5909,5938,5940,5970,5971,6002,6003,6068,6099,6109,6109,
		6112,6121,6155,6157,6159,6169,6313,6313,6432,6443,6448,6459,6470,6479,
		6608,6618,6679,6683,6741,6750,6752,6780,6783,6793,6800,6809,6832,6845,
		6847,6862,6912,6916,6964,6980,6992,7001,7019,7027,7040,7042,7073,7085,
		7088,7097,7142,7155,7204,7223,7232,7241,7248,7257,7376,7378,7380,7400,
		7405,7405,7412,7412,7415,7417,7616,7679,8255,8256,8276,8276,8400,8412,
		8417,8417,8421,8432,11503,11505,11647,11647,11744,11775,12330,12335,12441,
		12442,42528,42537,42607,42607,42612,42621,42654,42655,42736,42737,43010,
		43010,43014,43014,43019,43019,43043,43047,43052,43052,43136,43137,43188,
		43205,43216,43225,43232,43249,43263,43273,43302,43309,43335,43347,43392,
		43395,43443,43456,43472,43481,43493,43493,43504,43513,43561,43574,43587,
		43587,43596,43597,43600,43609,43643,43645,43696,43696,43698,43700,43703,
		43704,43710,43711,43713,43713,43755,43759,43765,43766,44003,44010,44012,
		44013,44016,44025,64286,64286,65024,65039,65056,65071,65075,65076,65101,
		65103,65296,65305,65343,65343,65438,65439,66045,66045,66272,66272,66422,
		66426,66720,66729,68097,68099,68101,68102,68108,68111,68152,68154,68159,
		68159,68325,68326,68900,68903,68912,68921,69291,69292,69373,69375,69446,
		69456,69506,69509,69632,69634,69688,69702,69734,69744,69747,69748,69759,
		69762,69808,69818,69826,69826,69872,69881,69888,69890,69927,69940,69942,
		69951,69957,69958,70003,70003,70016,70018,70067,70080,70089,70092,70094,
		70105,70188,70199,70206,70206,70209,70209,70367,70378,70384,70393,70400,
		70403,70459,70460,70462,70468,70471,70472,70475,70477,70487,70487,70498,
		70499,70502,70508,70512,70516,70709,70726,70736,70745,70750,70750,70832,
		70851,70864,70873,71087,71093,71096,71104,71132,71133,71216,71232,71248,
		71257,71339,71351,71360,71369,71453,71467,71472,71481,71724,71738,71904,
		71913,71984,71989,71991,71992,71995,71998,72000,72000,72002,72003,72016,
		72025,72145,72151,72154,72160,72164,72164,72193,72202,72243,72249,72251,
		72254,72263,72263,72273,72283,72330,72345,72751,72758,72760,72767,72784,
		72793,72850,72871,72873,72886,73009,73014,73018,73018,73020,73021,73023,
		73029,73031,73031,73040,73049,73098,73102,73104,73105,73107,73111,73120,
		73129,73459,73462,73472,73473,73475,73475,73524,73530,73534,73538,73552,
		73561,78912,78912,78919,78933,92768,92777,92864,92873,92912,92916,92976,
		92982,93008,93017,94031,94031,94033,94087,94095,94098,94180,94180,94192,
		94193,113821,113822,118528,118573,118576,118598,119141,119145,119149,119154,
		119163,119170,119173,119179,119210,119213,119362,119364,120782,120831,
		121344,121398,121403,121452,121461,121461,121476,121476,121499,121503,
		121505,121519,122880,122886,122888,122904,122907,122913,122915,122916,
		122918,122922,123023,123023,123184,123190,123200,123209,123566,123566,
		123628,123641,124140,124153,125136,125142,125252,125258,125264,125273,
		130032,130041,917760,917999,667,0,65,90,95,95,97,122,170,170,181,181,186,
		186,192,214,216,246,248,705,710,721,736,740,748,748,750,750,880,884,886,
		887,891,893,895,895,902,902,904,906,908,908,910,929,931,1013,1015,1153,
		1162,1327,1329,1366,1369,1369,1376,1416,1488,1514,1519,1522,1568,1610,
		1646,1647,1649,1747,1749,1749,1765,1766,1774,1775,1786,1788,1791,1791,
		1808,1808,1810,1839,1869,1957,1969,1969,1994,2026,2036,2037,2042,2042,
		2048,2069,2074,2074,2084,2084,2088,2088,2112,2136,2144,2154,2160,2183,
		2185,2190,2208,2249,2308,2361,2365,2365,2384,2384,2392,2401,2417,2432,
		2437,2444,2447,2448,2451,2472,2474,2480,2482,2482,2486,2489,2493,2493,
		2510,2510,2524,2525,2527,2529,2544,2545,2556,2556,2565,2570,2575,2576,
		2579,2600,2602,2608,2610,2611,2613,2614,2616,2617,2649,2652,2654,2654,
		2674,2676,2693,2701,2703,2705,2707,2728,2730,2736,2738,2739,2741,2745,
		2749,2749,2768,2768,2784,2785,2809,2809,2821,2828,2831,2832,2835,2856,
		2858,2864,2866,2867,2869,2873,2877,2877,2908,2909,2911,2913,2929,2929,
		2947,2947,2949,2954,2958,2960,2962,2965,2969,2970,2972,2972,2974,2975,
		2979,2980,2984,2986,2990,3001,3024,3024,3077,3084,3086,3088,3090,3112,
		3114,3129,3133,3133,3160,3162,3165,3165,3168,3169,3200,3200,3205,3212,
		3214,3216,3218,3240,3242,3251,3253,3257,3261,3261,3293,3294,3296,3297,
		3313,3314,3332,3340,3342,3344,3346,3386,3389,3389,3406,3406,3412,3414,
		3423,3425,3450,3455,3461,3478,3482,3505,3507,3515,3517,3517,3520,3526,
		3585,3632,3634,3634,3648,3654,3713,3714,3716,3716,3718,3722,3724,3747,
		3749,3749,3751,3760,3762,3762,3773,3773,3776,3780,3782,3782,3804,3807,
		3840,3840,3904,3911,3913,3948,3976,3980,4096,4138,4159,4159,4176,4181,
		4186,4189,4193,4193,4197,4198,4206,4208,4213,4225,4238,4238,4256,4293,
		4295,4295,4301,4301,4304,4346,4348,4680,4682,4685,4688,4694,4696,4696,
		4698,4701,4704,4744,4746,4749,4752,4784,4786,4789,4792,4798,4800,4800,
		4802,4805,4808,4822,4824,4880,4882,4885,4888,4954,4992,5007,5024,5109,
		5112,5117,5121,5740,5743,5759,5761,5786,5792,5866,5870,5880,5888,5905,
		5919,5937,5952,5969,5984,5996,5998,6000,6016,6067,6103,6103,6108,6108,
		6176,6264,6272,6312,6314,6314,6320,6389,6400,6430,6480,6509,6512,6516,
		6528,6571,6576,6601,6656,6678,6688,6740,6823,6823,6917,6963,6981,6988,
		7043,7072,7086,7087,7098,7141,7168,7203,7245,7247,7258,7293,7296,7304,
		7312,7354,7357,7359,7401,7404,7406,7411,7413,7414,7418,7418,7424,7615,
		7680,7957,7960,7965,7968,8005,8008,8013,8016,8023,8025,8025,8027,8027,
		8029,8029,8031,8061,8064,8116,8118,8124,8126,8126,8130,8132,8134,8140,
		8144,8147,8150,8155,8160,8172,8178,8180,8182,8188,8305,8305,8319,8319,
		8336,8348,8450,8450,8455,8455,8458,8467,8469,8469,8472,8477,8484,8484,
		8486,8486,8488,8488,8490,8505,8508,8511,8517,8521,8526,8526,8544,8584,
		11264,11492,11499,11502,11506,11507,11520,11557,11559,11559,11565,11565,
		11568,11623,11631,11631,11648,11670,11680,11686,11688,11694,11696,11702,
		11704,11710,11712,11718,11720,11726,11728,11734,11736,11742,12293,12295,
		12321,12329,12337,12341,12344,12348,12353,12438,12445,12447,12449,12538,
		12540,12543,12549,12591,12593,12686,12704,12735,12784,12799,13312,19903,
		19968,42124,42192,42237,42240,42508,42512,42527,42538,42539,42560,42606,
		42623,42653,42656,42735,42775,42783,42786,42888,42891,42954,42960,42961,
		42963,42963,42965,42969,42994,43009,43011,43013,43015,43018,43020,43042,
		43072,43123,43138,43187,43250,43255,43259,43259,43261,43262,43274,43301,
		43312,43334,43360,43388,43396,43442,43471,43471,43488,43492,43494,43503,
		43514,43518,43520,43560,43584,43586,43588,43595,43616,43638,43642,43642,
		43646,43695,43697,43697,43701,43702,43705,43709,43712,43712,43714,43714,
		43739,43741,43744,43754,43762,43764,43777,43782,43785,43790,43793,43798,
		43808,43814,43816,43822,43824,43866,43868,43881,43888,44002,44032,55203,
		55216,55238,55243,55291,63744,64109,64112,64217,64256,64262,64275,64279,
		64285,64285,64287,64296,64298,64310,64312,64316,64318,64318,64320,64321,
		64323,64324,64326,64433,64467,64605,64612,64829,64848,64911,64914,64967,
		65008,65017,65137,65137,65139,65139,65143,65143,65145,65145,65147,65147,
		65149,65149,65151,65276,65313,65338,65345,65370,65382,65437,65440,65470,
		65474,65479,65482,65487,65490,65495,65498,65500,65536,65547,65549,65574,
		65576,65594,65596,65597,65599,65613,65616,65629,65664,65786,65856,65908,
		66176,66204,66208,66256,66304,66335,66349,66378,66384,66421,66432,66461,
		66464,66499,66504,66511,66513,66517,66560,66717,66736,66771,66776,66811,
		66816,66855,66864,66915,66928,66938,66940,66954,66956,66962,66964,66965,
		66967,66977,66979,66993,66995,67001,67003,67004,67072,67382,67392,67413,
		67424,67431,67456,67461,67463,67504,67506,67514,67584,67589,67592,67592,
		67594,67637,67639,67640,67644,67644,67647,67669,67680,67702,67712,67742,
		67808,67826,67828,67829,67840,67861,67872,67897,67968,68023,68030,68031,
		68096,68096,68112,68115,68117,68119,68121,68149,68192,68220,68224,68252,
		68288,68295,68297,68324,68352,68405,68416,68437,68448,68466,68480,68497,
		68608,68680,68736,68786,68800,68850,68864,68899,69248,69289,69296,69297,
		69376,69404,69415,69415,69424,69445,69488,69505,69552,69572,69600,69622,
		69635,69687,69745,69746,69749,69749,69763,69807,69840,69864,69891,69926,
		69956,69956,69959,69959,69968,70002,70006,70006,70019,70066,70081,70084,
		70106,70106,70108,70108,70144,70161,70163,70187,70207,70208,70272,70278,
		70280,70280,70282,70285,70287,70301,70303,70312,70320,70366,70405,70412,
		70415,70416,70419,70440,70442,70448,70450,70451,70453,70457,70461,70461,
		70480,70480,70493,70497,70656,70708,70727,70730,70751,70753,70784,70831,
		70852,70853,70855,70855,71040,71086,71128,71131,71168,71215,71236,71236,
		71296,71338,71352,71352,71424,71450,71488,71494,71680,71723,71840,71903,
		71935,71942,71945,71945,71948,71955,71957,71958,71960,71983,71999,71999,
		72001,72001,72096,72103,72106,72144,72161,72161,72163,72163,72192,72192,
		72203,72242,72250,72250,72272,72272,72284,72329,72349,72349,72368,72440,
		72704,72712,72714,72750,72768,72768,72818,72847,72960,72966,72968,72969,
		72971,73008,73030,73030,73056,73061,73063,73064,73066,73097,73112,73112,
		73440,73458,73474,73474,73476,73488,73490,73523,73648,73648,73728,74649,
		74752,74862,74880,75075,77712,77808,77824,78895,78913,78918,82944,83526,
		92160,92728,92736,92766,92784,92862,92880,92909,92928,92975,92992,92995,
		93027,93047,93053,93071,93760,93823,93952,94026,94032,94032,94099,94111,
		94176,94177,94179,94179,94208,100343,100352,101589,101632,101640,110576,
		110579,110581,110587,110589,110590,110592,110882,110898,110898,110928,
		110930,110933,110933,110948,110951,110960,111355,113664,113770,113776,
		113788,113792,113800,113808,113817,119808,119892,119894,119964,119966,
		119967,119970,119970,119973,119974,119977,119980,119982,119993,119995,
		119995,119997,120003,120005,120069,120071,120074,120077,120084,120086,
		120092,120094,120121,120123,120126,120128,120132,120134,120134,120138,
		120144,120146,120485,120488,120512,120514,120538,120540,120570,120572,
		120596,120598,120628,120630,120654,120656,120686,120688,120712,120714,
		120744,120746,120770,120772,120779,122624,122654,122661,122666,122928,
		122989,123136,123180,123191,123197,123214,123214,123536,123565,123584,
		123627,124112,124139,124896,124902,124904,124907,124909,124910,124912,
		124926,124928,125124,125184,125251,125259,125259,126464,126467,126469,
		126495,126497,126498,126500,126500,126503,126503,126505,126514,126516,
		126519,126521,126521,126523,126523,126530,126530,126535,126535,126537,
		126537,126539,126539,126541,126543,126545,126546,126548,126548,126551,
		126551,126553,126553,126555,126555,126557,126557,126559,126559,126561,
		126562,126564,126564,126567,126570,126572,126578,126580,126583,126585,
		126588,126590,126590,126592,126601,126603,126619,126625,126627,126629,
		126633,126635,126651,131072,173791,173824,177977,177984,178205,178208,
		183969,183984,191456,194560,195101,196608,201546,201552,205743,451,0,1,
		1,0,0,0,0,3,1,0,0,0,0,5,1,0,0,0,0,7,1,0,0,0,0,9,1,0,0,0,0,11,1,0,0,0,0,
		13,1,0,0,0,0,15,1,0,0,0,0,17,1,0,0,0,0,19,1,0,0,0,0,21,1,0,0,0,0,23,1,
		0,0,0,0,25,1,0,0,0,0,27,1,0,0,0,0,29,1,0,0,0,0,31,1,0,0,0,0,33,1,0,0,0,
		0,35,1,0,0,0,0,37,1,0,0,0,0,39,1,0,0,0,0,41,1,0,0,0,0,43,1,0,0,0,0,45,
		1,0,0,0,0,47,1,0,0,0,0,49,1,0,0,0,0,51,1,0,0,0,0,53,1,0,0,0,0,55,1,0,0,
		0,0,89,1,0,0,0,0,91,1,0,0,0,0,93,1,0,0,0,0,95,1,0,0,0,0,97,1,0,0,0,1,121,
		1,0,0,0,3,127,1,0,0,0,5,132,1,0,0,0,7,137,1,0,0,0,9,142,1,0,0,0,11,149,
		1,0,0,0,13,154,1,0,0,0,15,159,1,0,0,0,17,164,1,0,0,0,19,170,1,0,0,0,21,
		175,1,0,0,0,23,177,1,0,0,0,25,179,1,0,0,0,27,181,1,0,0,0,29,183,1,0,0,
		0,31,185,1,0,0,0,33,187,1,0,0,0,35,189,1,0,0,0,37,191,1,0,0,0,39,193,1,
		0,0,0,41,195,1,0,0,0,43,197,1,0,0,0,45,199,1,0,0,0,47,201,1,0,0,0,49,204,
		1,0,0,0,51,207,1,0,0,0,53,216,1,0,0,0,55,220,1,0,0,0,57,226,1,0,0,0,59,
		252,1,0,0,0,61,254,1,0,0,0,63,264,1,0,0,0,65,274,1,0,0,0,67,284,1,0,0,
		0,69,286,1,0,0,0,71,288,1,0,0,0,73,290,1,0,0,0,75,294,1,0,0,0,77,298,1,
		0,0,0,79,307,1,0,0,0,81,311,1,0,0,0,83,315,1,0,0,0,85,325,1,0,0,0,87,328,
		1,0,0,0,89,335,1,0,0,0,91,339,1,0,0,0,93,349,1,0,0,0,95,355,1,0,0,0,97,
		360,1,0,0,0,99,378,1,0,0,0,101,382,1,0,0,0,103,386,1,0,0,0,105,388,1,0,
		0,0,107,390,1,0,0,0,109,418,1,0,0,0,111,422,1,0,0,0,113,424,1,0,0,0,115,
		431,1,0,0,0,117,435,1,0,0,0,119,437,1,0,0,0,121,122,5,108,0,0,122,123,
		5,97,0,0,123,124,5,98,0,0,124,125,5,101,0,0,125,126,5,108,0,0,126,2,1,
		0,0,0,127,128,5,106,0,0,128,129,5,117,0,0,129,130,5,109,0,0,130,131,5,
		112,0,0,131,4,1,0,0,0,132,133,5,99,0,0,133,134,5,97,0,0,134,135,5,108,
		0,0,135,136,5,108,0,0,136,6,1,0,0,0,137,138,5,112,0,0,138,139,5,97,0,0,
		139,140,5,115,0,0,140,141,5,115,0,0,141,8,1,0,0,0,142,143,5,114,0,0,143,
		144,5,101,0,0,144,145,5,116,0,0,145,146,5,117,0,0,146,147,5,114,0,0,147,
		148,5,110,0,0,148,10,1,0,0,0,149,150,5,119,0,0,150,151,5,105,0,0,151,152,
		5,116,0,0,152,153,5,104,0,0,153,12,1,0,0,0,154,155,5,109,0,0,155,156,5,
		101,0,0,156,157,5,110,0,0,157,158,5,117,0,0,158,14,1,0,0,0,159,160,5,84,
		0,0,160,161,5,114,0,0,161,162,5,117,0,0,162,163,5,101,0,0,163,16,1,0,0,
		0,164,165,5,70,0,0,165,166,5,97,0,0,166,167,5,108,0,0,167,168,5,115,0,
		0,168,169,5,101,0,0,169,18,1,0,0,0,170,171,5,78,0,0,171,172,5,111,0,0,
		172,173,5,110,0,0,173,174,5,101,0,0,174,20,1,0,0,0,175,176,5,40,0,0,176,
		22,1,0,0,0,177,178,5,91,0,0,178,24,1,0,0,0,179,180,5,123,0,0,180,26,1,
		0,0,0,181,182,5,41,0,0,182,28,1,0,0,0,183,184,5,93,0,0,184,30,1,0,0,0,
		185,186,5,125,0,0,186,32,1,0,0,0,187,188,5,43,0,0,188,34,1,0,0,0,189,190,
		5,45,0,0,190,36,1,0,0,0,191,192,5,46,0,0,192,38,1,0,0,0,193,194,5,58,0,
		0,194,40,1,0,0,0,195,196,5,61,0,0,196,42,1,0,0,0,197,198,5,44,0,0,198,
		44,1,0,0,0,199,200,5,42,0,0,200,46,1,0,0,0,201,202,5,42,0,0,202,203,5,
		42,0,0,203,48,1,0,0,0,204,205,5,58,0,0,205,206,5,61,0,0,206,50,1,0,0,0,
		207,211,3,119,59,0,208,210,3,117,58,0,209,208,1,0,0,0,210,213,1,0,0,0,
		211,209,1,0,0,0,211,212,1,0,0,0,212,52,1,0,0,0,213,211,1,0,0,0,214,217,
		3,99,49,0,215,217,3,109,54,0,216,214,1,0,0,0,216,215,1,0,0,0,217,54,1,
		0,0,0,218,221,3,57,28,0,219,221,3,77,38,0,220,218,1,0,0,0,220,219,1,0,
		0,0,221,56,1,0,0,0,222,227,3,59,29,0,223,227,3,61,30,0,224,227,3,63,31,
		0,225,227,3,65,32,0,226,222,1,0,0,0,226,223,1,0,0,0,226,224,1,0,0,0,226,
		225,1,0,0,0,227,58,1,0,0,0,228,235,3,67,33,0,229,231,5,95,0,0,230,229,
		1,0,0,0,230,231,1,0,0,0,231,232,1,0,0,0,232,234,3,69,34,0,233,230,1,0,
		0,0,234,237,1,0,0,0,235,233,1,0,0,0,235,236,1,0,0,0,236,253,1,0,0,0,237,
		235,1,0,0,0,238,240,5,48,0,0,239,238,1,0,0,0,240,241,1,0,0,0,241,239,1,
		0,0,0,241,242,1,0,0,0,242,249,1,0,0,0,243,245,5,95,0,0,244,243,1,0,0,0,
		244,245,1,0,0,0,245,246,1,0,0,0,246,248,5,48,0,0,247,244,1,0,0,0,248,251,
		1,0,0,0,249,247,1,0,0,0,249,250,1,0,0,0,250,253,1,0,0,0,251,249,1,0,0,
		0,252,228,1,0,0,0,252,239,1,0,0,0,253,60,1,0,0,0,254,255,5,48,0,0,255,
		260,7,0,0,0,256,258,5,95,0,0,257,256,1,0,0,0,257,258,1,0,0,0,258,259,1,
		0,0,0,259,261,3,71,35,0,260,257,1,0,0,0,261,262,1,0,0,0,262,260,1,0,0,
		0,262,263,1,0,0,0,263,62,1,0,0,0,264,265,5,48,0,0,265,270,7,1,0,0,266,
		268,5,95,0,0,267,266,1,0,0,0,267,268,1,0,0,0,268,269,1,0,0,0,269,271,3,
		73,36,0,270,267,1,0,0,0,271,272,1,0,0,0,272,270,1,0,0,0,272,273,1,0,0,
		0,273,64,1,0,0,0,274,275,5,48,0,0,275,280,7,2,0,0,276,278,5,95,0,0,277,
		276,1,0,0,0,277,278,1,0,0,0,278,279,1,0,0,0,279,281,3,75,37,0,280,277,
		1,0,0,0,281,282,1,0,0,0,282,280,1,0,0,0,282,283,1,0,0,0,283,66,1,0,0,0,
		284,285,7,3,0,0,285,68,1,0,0,0,286,287,7,4,0,0,287,70,1,0,0,0,288,289,
		2,48,49,0,289,72,1,0,0,0,290,291,7,5,0,0,291,74,1,0,0,0,292,295,3,69,34,
		0,293,295,7,6,0,0,294,292,1,0,0,0,294,293,1,0,0,0,295,76,1,0,0,0,296,299,
		3,79,39,0,297,299,3,81,40,0,298,296,1,0,0,0,298,297,1,0,0,0,299,78,1,0,
		0,0,300,302,3,83,41,0,301,300,1,0,0,0,301,302,1,0,0,0,302,303,1,0,0,0,
		303,308,3,85,42,0,304,305,3,83,41,0,305,306,5,46,0,0,306,308,1,0,0,0,307,
		301,1,0,0,0,307,304,1,0,0,0,308,80,1,0,0,0,309,312,3,83,41,0,310,312,3,
		79,39,0,311,309,1,0,0,0,311,310,1,0,0,0,312,313,1,0,0,0,313,314,3,87,43,
		0,314,82,1,0,0,0,315,322,3,69,34,0,316,318,5,95,0,0,317,316,1,0,0,0,317,
		318,1,0,0,0,318,319,1,0,0,0,319,321,3,69,34,0,320,317,1,0,0,0,321,324,
		1,0,0,0,322,320,1,0,0,0,322,323,1,0,0,0,323,84,1,0,0,0,324,322,1,0,0,0,
		325,326,5,46,0,0,326,327,3,83,41,0,327,86,1,0,0,0,328,330,7,7,0,0,329,
		331,7,8,0,0,330,329,1,0,0,0,330,331,1,0,0,0,331,332,1,0,0,0,332,333,3,
		83,41,0,333,88,1,0,0,0,334,336,5,13,0,0,335,334,1,0,0,0,335,336,1,0,0,
		0,336,337,1,0,0,0,337,338,5,10,0,0,338,90,1,0,0,0,339,343,5,35,0,0,340,
		342,8,9,0,0,341,340,1,0,0,0,342,345,1,0,0,0,343,341,1,0,0,0,343,344,1,
		0,0,0,344,346,1,0,0,0,345,343,1,0,0,0,346,347,6,45,0,0,347,92,1,0,0,0,
		348,350,7,10,0,0,349,348,1,0,0,0,350,351,1,0,0,0,351,349,1,0,0,0,351,352,
		1,0,0,0,352,353,1,0,0,0,353,354,6,46,0,0,354,94,1,0,0,0,355,356,5,92,0,
		0,356,357,3,89,44,0,357,358,1,0,0,0,358,359,6,47,0,0,359,96,1,0,0,0,360,
		361,9,0,0,0,361,98,1,0,0,0,362,366,5,39,0,0,363,365,3,101,50,0,364,363,
		1,0,0,0,365,368,1,0,0,0,366,364,1,0,0,0,366,367,1,0,0,0,367,369,1,0,0,
		0,368,366,1,0,0,0,369,379,5,39,0,0,370,374,5,34,0,0,371,373,3,103,51,0,
		372,371,1,0,0,0,373,376,1,0,0,0,374,372,1,0,0,0,374,375,1,0,0,0,375,377,
		1,0,0,0,376,374,1,0,0,0,377,379,5,34,0,0,378,362,1,0,0,0,378,370,1,0,0,
		0,379,100,1,0,0,0,380,383,3,105,52,0,381,383,3,115,57,0,382,380,1,0,0,
		0,382,381,1,0,0,0,383,102,1,0,0,0,384,387,3,107,53,0,385,387,3,115,57,
		0,386,384,1,0,0,0,386,385,1,0,0,0,387,104,1,0,0,0,388,389,8,11,0,0,389,
		106,1,0,0,0,390,391,8,12,0,0,391,108,1,0,0,0,392,393,5,39,0,0,393,394,
		5,39,0,0,394,395,5,39,0,0,395,399,1,0,0,0,396,398,3,111,55,0,397,396,1,
		0,0,0,398,401,1,0,0,0,399,400,1,0,0,0,399,397,1,0,0,0,400,402,1,0,0,0,
		401,399,1,0,0,0,402,403,5,39,0,0,403,404,5,39,0,0,404,419,5,39,0,0,405,
		406,5,34,0,0,406,407,5,34,0,0,407,408,5,34,0,0,408,412,1,0,0,0,409,411,
		3,111,55,0,410,409,1,0,0,0,411,414,1,0,0,0,412,413,1,0,0,0,412,410,1,0,
		0,0,413,415,1,0,0,0,414,412,1,0,0,0,415,416,5,34,0,0,416,417,5,34,0,0,
		417,419,5,34,0,0,418,392,1,0,0,0,418,405,1,0,0,0,419,110,1,0,0,0,420,423,
		3,113,56,0,421,423,3,115,57,0,422,420,1,0,0,0,422,421,1,0,0,0,423,112,
		1,0,0,0,424,425,8,13,0,0,425,114,1,0,0,0,426,427,5,92,0,0,427,428,5,13,
		0,0,428,432,5,10,0,0,429,430,5,92,0,0,430,432,9,0,0,0,431,426,1,0,0,0,
		431,429,1,0,0,0,432,116,1,0,0,0,433,436,3,119,59,0,434,436,7,14,0,0,435,
		433,1,0,0,0,435,434,1,0,0,0,436,118,1,0,0,0,437,438,7,15,0,0,438,120,1,
		0,0,0,39,0,211,216,220,226,230,235,241,244,249,252,257,262,267,272,277,
		282,294,298,301,307,311,317,322,330,335,343,351,366,374,378,382,386,399,
		412,418,422,431,435,1,0,1,0
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
