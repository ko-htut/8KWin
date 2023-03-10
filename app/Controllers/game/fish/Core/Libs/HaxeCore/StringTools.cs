// Generated by Haxe 3.4.4

#pragma warning disable 109, 114, 219, 429, 168, 162
public class StringTools : global::haxe.lang.HxObject {
	
	static StringTools() {
		unchecked {
			global::StringTools.winMetaCharacters = new global::ArrayHaxe<int>(new int[]{32, 40, 41, 37, 33, 94, 34, 60, 62, 38, 124, 10, 13, 44, 59});
		}
	}
	
	
	public StringTools(global::haxe.lang.EmptyObject empty) {
	}
	
	
	public StringTools() {
		global::StringTools.__hx_ctor__StringTools(this);
	}
	
	
	public static void __hx_ctor__StringTools(global::StringTools __hx_this) {
	}
	
	
	public static string urlEncode(string s) {
		return global::System.Uri.EscapeDataString(((string) (s) ));
	}
	
	
	public static string urlDecode(string s) {
		return global::System.Uri.UnescapeDataString(((string) (s) ));
	}
	
	
	public static string htmlEscape(string s, global::haxe.lang.Null<bool> quotes) {
		s = global::haxe.lang.StringExt.split(global::haxe.lang.StringExt.split(global::haxe.lang.StringExt.split(s, "&").@join("&amp;"), "<").@join("&lt;"), ">").@join("&gt;");
		if (((quotes)).@value) {
			return global::haxe.lang.StringExt.split(global::haxe.lang.StringExt.split(s, "\"").@join("&quot;"), "\'").@join("&#039;");
		}
		else {
			return s;
		}
		
	}
	
	
	public static string htmlUnescape(string s) {
		return global::haxe.lang.StringExt.split(global::haxe.lang.StringExt.split(global::haxe.lang.StringExt.split(global::haxe.lang.StringExt.split(global::haxe.lang.StringExt.split(s, "&gt;").@join(">"), "&lt;").@join("<"), "&quot;").@join("\""), "&#039;").@join("\'"), "&amp;").@join("&");
	}
	
	
	public static bool startsWith(string s, string start) {
		return s.StartsWith(start);
	}
	
	
	public static bool endsWith(string s, string end) {
		return s.EndsWith(end);
	}
	
	
	public static bool isSpace(string s, int pos) {
		unchecked {
			global::haxe.lang.Null<int> c = global::haxe.lang.StringExt.charCodeAt(s, pos);
			if ( ! ((( ( (c).@value > 8 ) && ( (c).@value < 14 ) ))) ) {
				return global::haxe.lang.Runtime.eq((c).toDynamic(), 32);
			}
			else {
				return true;
			}
			
		}
	}
	
	
	public static string ltrim(string s) {
		return s.TrimStart();
	}
	
	
	public static string rtrim(string s) {
		return s.TrimEnd();
	}
	
	
	public static string trim(string s) {
		return s.Trim();
	}
	
	
	public static string lpad(string s, string c, int l) {
		if (( c.Length <= 0 )) {
			return s;
		}
		
		while (( s.Length < l )) {
			s = global::haxe.lang.Runtime.concat(c, s);
		}
		
		return s;
	}
	
	
	public static string rpad(string s, string c, int l) {
		if (( c.Length <= 0 )) {
			return s;
		}
		
		while (( s.Length < l )) {
			s = global::haxe.lang.Runtime.concat(s, c);
		}
		
		return s;
	}
	
	
	public static string replace(string s, string sub, string @by) {
		if (( sub.Length == 0 )) {
			return global::haxe.lang.StringExt.split(s, sub).@join(@by);
		}
		else {
			return s.Replace(sub, @by);
		}
		
	}
	
	
	public static string hex(int n, global::haxe.lang.Null<int> digits) {
		unchecked {
			string s = "";
			string hexChars = "0123456789ABCDEF";
			while (true) {
				s = global::haxe.lang.Runtime.concat(global::haxe.lang.StringExt.charAt(hexChars, ( n & 15 )), s);
				n = ((int) (( ((uint) (n) ) >> 4 )) );
				if ( ! ((( n > 0 ))) ) {
					break;
				}
				
			}
			
			if (digits.hasValue) {
				while (( s.Length < (digits).@value )) {
					s = global::haxe.lang.Runtime.concat("0", s);
				}
				
			}
			
			return s;
		}
	}
	
	
	public static int fastCodeAt(string s, int index) {
		unchecked {
			if (((bool) (( ((uint) (index) ) < s.Length )) )) {
				return ((int) (s[index]) );
			}
			else {
				return -1;
			}
			
		}
	}
	
	
	public static bool isEof(int c) {
		unchecked {
			return ( c == -1 );
		}
	}
	
	
	public static string quoteUnixArg(string argument) {
		if (string.Equals(argument, "")) {
			return "\'\'";
		}
		
		if ( ! (new global::EReg("[^a-zA-Z0-9_@%+=:,./-]", "").match(argument)) ) {
			return argument;
		}
		
		return global::haxe.lang.Runtime.concat(global::haxe.lang.Runtime.concat("\'", global::StringTools.replace(argument, "\'", "\'\"\'\"\'")), "\'");
	}
	
	
	public static global::ArrayHaxe<int> winMetaCharacters;
	
	public static string quoteWinArg(string argument, bool escapeMetaCharacters) {
		unchecked {
			if ( ! (new global::EReg("^[^ \t\\\\\"]+$", "").match(argument)) ) {
				global::System.Text.StringBuilder result_b = new global::System.Text.StringBuilder();
				bool needquote = ( ( ( global::haxe.lang.StringExt.indexOf(argument, " ", default(global::haxe.lang.Null<int>)) != -1 ) || ( global::haxe.lang.StringExt.indexOf(argument, "\t", default(global::haxe.lang.Null<int>)) != -1 ) ) || string.Equals(argument, "") );
				if (needquote) {
					result_b.Append(((string) ("\"") ));
				}
				
				global::StringBuf bs_buf = new global::StringBuf();
				{
					int _g1 = 0;
					int _g = argument.Length;
					while (( _g1 < _g )) {
						int i = _g1++;
						{
							global::haxe.lang.Null<int> _g2 = global::haxe.lang.StringExt.charCodeAt(argument, i);
							if ( ! (_g2.hasValue) ) {
								global::haxe.lang.Null<int> c = _g2;
								{
									if (( bs_buf.b.Length > 0 )) {
										result_b.Append(((string) (global::Std.@string(bs_buf.b.ToString())) ));
										bs_buf = new global::StringBuf();
									}
									
									result_b.Append(((char) ((c).@value) ));
								}
								
							}
							else {
								switch (((_g2)).@value) {
									case 34:
									{
										string bs = bs_buf.b.ToString();
										result_b.Append(((string) (global::Std.@string(bs)) ));
										result_b.Append(((string) (global::Std.@string(bs)) ));
										bs_buf = new global::StringBuf();
										result_b.Append(((string) ("\\\"") ));
										break;
									}
									
									
									case 92:
									{
										bs_buf.b.Append(((string) ("\\") ));
										break;
									}
									
									
									default:
									{
										global::haxe.lang.Null<int> c1 = _g2;
										{
											if (( bs_buf.b.Length > 0 )) {
												result_b.Append(((string) (global::Std.@string(bs_buf.b.ToString())) ));
												bs_buf = new global::StringBuf();
											}
											
											result_b.Append(((char) ((c1).@value) ));
										}
										
										break;
									}
									
								}
								
							}
							
						}
						
					}
					
				}
				
				result_b.Append(((string) (global::Std.@string(bs_buf.b.ToString())) ));
				if (needquote) {
					result_b.Append(((string) (global::Std.@string(bs_buf.b.ToString())) ));
					result_b.Append(((string) ("\"") ));
				}
				
				argument = result_b.ToString();
			}
			
			if (escapeMetaCharacters) {
				global::System.Text.StringBuilder result_b1 = new global::System.Text.StringBuilder();
				{
					int _g11 = 0;
					int _g3 = argument.Length;
					while (( _g11 < _g3 )) {
						int i1 = _g11++;
						global::haxe.lang.Null<int> c2 = global::haxe.lang.StringExt.charCodeAt(argument, i1);
						if (( global::StringTools.winMetaCharacters.indexOf((c2).@value, default(global::haxe.lang.Null<int>)) >= 0 )) {
							result_b1.Append(((char) (94) ));
						}
						
						result_b1.Append(((char) ((c2).@value) ));
					}
					
				}
				
				return result_b1.ToString();
			}
			else {
				return argument;
			}
			
		}
	}
	
	
}


