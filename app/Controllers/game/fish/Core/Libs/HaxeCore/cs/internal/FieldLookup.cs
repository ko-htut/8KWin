// Generated by Haxe 3.4.4

#pragma warning disable 109, 114, 219, 429, 168, 162
namespace haxe.lang {
	public sealed class FieldHashConflict {
		
		public FieldHashConflict(int hash, string name, object @value, global::haxe.lang.FieldHashConflict next) {
			this.hash = hash;
			this.name = name;
			this.@value = @value;
			this.next = next;
		}
		
		
		public readonly int hash;
		
		public readonly string name;
		
		public object @value;
		
		public global::haxe.lang.FieldHashConflict next;
		
	}
}



#pragma warning disable 109, 114, 219, 429, 168, 162
namespace haxe.lang {
	public sealed class FieldLookup {
		
		#pragma warning disable 628
		static FieldLookup() {
			global::haxe.lang.FieldLookup.length = ( global::haxe.lang.FieldLookup.fieldIds as global::System.Array ).Length;
		}
		
		
		public FieldLookup() {
		}
		
		
		protected static int[] fieldIds = new int[]{97, 98, 99, 100, 105, 109, 120, 121, 25988, 25989, 26140, 26141, 1332402, 1821933, 4745537, 4846113, 4849249, 4949376, 4996429, 4997769, 5047259, 5144726, 5243965, 5343647, 5393365, 5442204, 5442212, 5443986, 5594513, 5594516, 5690858, 5741474, 24046298, 42740551, 52644165, 57219237, 57915666, 67859554, 76061764, 87367608, 96903864, 125111323, 142301684, 143015230, 159136996, 222029606, 244830897, 261031087, 291546447, 291546448, 302979532, 311465992, 319595299, 328878574, 338049424, 338842564, 342545746, 342545747, 353204262, 359333139, 373703110, 407283053, 416386789, 416573132, 427325412, 451001976, 452737314, 480756972, 489282032, 489282033, 494170129, 494170130, 495490704, 501039929, 520590566, 520665567, 523203586, 527294961, 532905732, 534308630, 561922075, 567156347, 596483356, 612773114, 614073432, 650184164, 688931719, 714931245, 714931246, 724060212, 731985805, 749558359, 749558360, 757104279, 808122571, 808122572, 821481554, 828582484, 833337176, 834174833, 845179051, 850732925, 910198946, 922671056, 946786476, 959399230, 966728099, 991811682, 991811683, 995006396, 1009117838, 1009117839, 1033892167, 1036338360, 1041537810, 1067353468, 1071652316, 1103412149, 1108126720, 1113806378, 1126920507, 1143436065, 1143436066, 1154932936, 1155848147, 1167273324, 1181037546, 1191633396, 1202718727, 1204816148, 1213952397, 1214452573, 1224700491, 1224901875, 1233114958, 1247873989, 1247875546, 1248019663, 1257939113, 1260406363, 1269061383, 1269061384, 1269755426, 1271070480, 1280549057, 1280845662, 1280991104, 1282943179, 1291236569, 1291438162, 1313416818, 1324990054, 1331294280, 1337394146, 1344025757, 1352786672, 1385764027, 1395555037, 1423782669, 1474015259, 1516836564, 1532710347, 1537812987, 1547539107, 1620824029, 1621420777, 1623148745, 1639293562, 1643967310, 1648581351, 1692511090, 1705629508, 1723805383, 1724402127, 1768164316, 1772189044, 1779810297, 1781145963, 1792286664, 1797611211, 1800886518, 1830310359, 1862383618, 1891834246, 1915412854, 1916009602, 1958090187, 1981972957, 2012934199, 2014410004, 2022294396, 2025055113, 2026819210, 2048392659, 2049940315, 2049940316, 2082267937, 2082663554, 2083500811, 2105901768, 2113708439, 2123232567, 2127021138};
		
		protected static string[] fields = new string[]{"a", "b", "c", "d", "i", "m", "x", "y", "tx", "ty", "u1", "u2", "get_position", "isGlobal", "__a", "add", "arr", "cur", "dir", "dot", "end", "get", "idx", "key", "len", "map", "max", "min", "pop", "pos", "ray", "set", "split", "flags", "match", "compare", "compose", "start", "remove", "filter", "merge", "hashCode", "resize", "rotation", "matched", "setLoop", "compareArg", "get_length", "get_x", "get_y", "methodName", "_position", "set_length", "iterator", "_rotation_radians", "total", "separationX", "separationY", "set_position", "lastIndexOf", "active", "hasNext", "_transformedVertices", "_transformed", "transformedVertices", "keysLoop", "reverse", "nOccupied", "shape1", "shape2", "unitVectorX", "unitVectorY", "dir_cache", "insert", "length", "addSub", "get_vertices", "_radius", "lengthsq", "invert", "get_radius", "get_transformedVertices", "balance", "destroy", "matchedRight", "get_dir", "overlap", "_scaleX", "_scaleY", "replace", "normalize", "get_scaleX", "get_scaleY", "otherOverlap", "set_scaleX", "set_scaleY", "radius", "get_transformedRadius", "_vertices", "value", "quotient", "transformedRadius", "compareArgs", "cachedIndex", "toString", "identity", "makeTranslation", "otherSeparationX", "otherSeparationY", "hashes", "scaleX", "scaleY", "get_rotation", "testRay", "index", "splice", "exists", "copy", "items", "data", "matchSub", "otherUnitVectorX", "otherUnitVectorY", "removeLoop", "minBinding", "transform", "join", "keys", "left", "concat", "clear", "clone", "name", "next", "translate", "pull", "push", "count", "position", "rotate", "ray1", "ray2", "root", "matchedPos", "size", "sort", "cross", "quicksort", "tags", "test", "vals", "truncate", "testPolygon", "values", "_rotation", "spliceVoid", "set_rotation", "cachedKey", "get_lengthsq", "get_total", "infinite", "concatNative", "nBuckets", "className", "__unsafe_get", "__unsafe_set", "indexOf", "lookup", "_transformMatrix", "fileName", "iteratorLoop", "toDynamic", "regex", "reset", "right", "copy_from", "vertices", "__hx_constructs", "_last_rotation", "getDefault", "results", "customParams", "testCircle", "_height", "__get", "__set", "_scale", "lineNumber", "modulus", "subtract", "upperBound", "unshift", "scale", "_keys", "set_x", "set_y", "shape", "shift", "matchedLeft", "refresh_transform", "addChar", "removeMinBinding", "slice"};
		
		protected static int length;
		
		public static void addFields(int[] nids, string[] nfields) {
			unchecked {
				int[] cids = global::haxe.lang.FieldLookup.fieldIds;
				string[] cfields = global::haxe.lang.FieldLookup.fields;
				int nlen = ( nids as global::System.Array ).Length;
				int clen = global::haxe.lang.FieldLookup.length;
				if (( ( nfields as global::System.Array ).Length != nlen )) {
					throw global::haxe.lang.HaxeException.wrap(global::haxe.lang.Runtime.concat(global::haxe.lang.Runtime.concat(global::haxe.lang.Runtime.concat("Different fields length: ", global::haxe.lang.Runtime.toString(nlen)), " and "), global::haxe.lang.Runtime.toString(( nfields as global::System.Array ).Length)));
				}
				
				bool needsChange = false;
				{
					uint _g_idx = default(uint);
					int[] _g_arr = nids;
					_g_idx = ((uint) (0) );
					while (((bool) (( _g_idx < ( _g_arr as global::System.Array ).Length )) )) {
						int i = ((int) (_g_arr[((int) (_g_idx++) )]) );
						if (( global::haxe.lang.FieldLookup.findHash(i, cids, clen) < 0 )) {
							needsChange = true;
							break;
						}
						
					}
					
				}
				
				if (needsChange) {
					lock(typeof(global::haxe.lang.FieldLookup)){
						int[] ansIds = new int[( clen + nlen )];
						string[] ansFields = new string[( clen + nlen )];
						int ci = 0;
						int ni = 0;
						int ansi = 0;
						while (true) {
							if ( ! ((( (( ci < clen )) ? (( ni < nlen )) : (false) ))) ) {
								break;
							}
							
							if (( cids[ci] < nids[ni] )) {
								ansIds[ansi] = cids[ci];
								ansFields[ansi] = cfields[ci];
								ci = ( ci + 1 );
							}
							else {
								ansIds[ansi] = nids[ni];
								ansFields[ansi] = nfields[ni];
								ni = ( ni + 1 );
							}
							
							ansi = ( ansi + 1 );
						}
						
						if (( ci < clen )) {
							global::System.Array.Copy(((global::System.Array) (cids) ), ((int) (ci) ), ((global::System.Array) (ansIds) ), ((int) (ansi) ), ((int) (( clen - ci )) ));
							global::System.Array.Copy(((global::System.Array) (cfields) ), ((int) (ci) ), ((global::System.Array) (ansFields) ), ((int) (ansi) ), ((int) (( clen - ci )) ));
							ansi = ( ansi + (( clen - ci )) );
						}
						
						if (( ni < nlen )) {
							global::System.Array.Copy(((global::System.Array) (nids) ), ((int) (ni) ), ((global::System.Array) (ansIds) ), ((int) (ansi) ), ((int) (( nlen - ni )) ));
							global::System.Array.Copy(((global::System.Array) (nfields) ), ((int) (ni) ), ((global::System.Array) (ansFields) ), ((int) (ansi) ), ((int) (( nlen - ni )) ));
							ansi = ( ansi + (( nlen - ni )) );
						}
						
						global::haxe.lang.FieldLookup.fieldIds = ansIds;
						global::haxe.lang.FieldLookup.fields = ansFields;
						global::haxe.lang.FieldLookup.length = ansi;
					}
					;
				}
				
			}
		}
		
		
		public static int doHash(string s) {
			unchecked {
				int acc = 0;
				{
					int _g1 = 0;
					int _g = s.Length;
					while (( _g1 < _g )) {
						int i = _g1++;
						acc = ( ( ( 223 * (( acc >> 1 )) ) + ((int) (s[i]) ) ) << 1 );
					}
					
				}
				
				return ((int) (( ((uint) (acc) ) >> 1 )) );
			}
		}
		
		
		public static string lookupHash(int key) {
			unchecked {
				int[] ids = global::haxe.lang.FieldLookup.fieldIds;
				int min = 0;
				int max = global::haxe.lang.FieldLookup.length;
				while (( min < max )) {
					int mid = ( min + ( (( max - min )) / 2 ) );
					int imid = ids[mid];
					if (( key < imid )) {
						max = mid;
					}
					else if (( key > imid )) {
						min = ( mid + 1 );
					}
					else {
						return global::haxe.lang.FieldLookup.fields[mid];
					}
					
				}
				
				throw global::haxe.lang.HaxeException.wrap(global::haxe.lang.Runtime.concat("Field not found for hash ", global::haxe.lang.Runtime.toString(key)));
			}
		}
		
		
		public static int hash(string s) {
			unchecked {
				if (string.Equals(s, null)) {
					return 0;
				}
				
				int acc = 0;
				{
					int _g1 = 0;
					int _g = s.Length;
					while (( _g1 < _g )) {
						int i = _g1++;
						acc = ( ( ( 223 * (( acc >> 1 )) ) + ((int) (s[i]) ) ) << 1 );
					}
					
				}
				
				int key = ((int) (( ((uint) (acc) ) >> 1 )) );
				int[] ids = global::haxe.lang.FieldLookup.fieldIds;
				string[] fld = global::haxe.lang.FieldLookup.fields;
				int min = 0;
				int max = global::haxe.lang.FieldLookup.length;
				int len = global::haxe.lang.FieldLookup.length;
				while (( min < max )) {
					int mid = ((int) (( min + ( ((double) ((( max - min ))) ) / 2 ) )) );
					int imid = ids[mid];
					if (( key < imid )) {
						max = mid;
					}
					else if (( key > imid )) {
						min = ( mid + 1 );
					}
					else {
						string field = fld[mid];
						if ( ! (string.Equals(field, s)) ) {
							return  ~ (key) ;
						}
						
						return key;
					}
					
				}
				
				lock(typeof(global::haxe.lang.FieldLookup)){
					if (( len != global::haxe.lang.FieldLookup.length )) {
						return global::haxe.lang.FieldLookup.hash(s);
					}
					
					global::haxe.lang.FieldLookup.insert<int>(ref global::haxe.lang.FieldLookup.fieldIds, ((int) (global::haxe.lang.FieldLookup.length) ), ((int) (min) ), ((int) (key) ));
					global::haxe.lang.FieldLookup.insert<string>(ref global::haxe.lang.FieldLookup.fields, ((int) (global::haxe.lang.FieldLookup.length) ), ((int) (min) ), ((string) (s) ));
					 ++ global::haxe.lang.FieldLookup.length;
				}
				;
				return key;
			}
		}
		
		
		public static int findHash(int hash, int[] hashs, int length) {
			unchecked {
				int min = 0;
				int max = length;
				while (( min < max )) {
					int mid = ( (( max + min )) / 2 );
					int imid = hashs[mid];
					if (( hash < imid )) {
						max = mid;
					}
					else if (( hash > imid )) {
						min = ( mid + 1 );
					}
					else {
						return mid;
					}
					
				}
				
				return  ~ (min) ;
			}
		}
		
		
		public static void @remove<T>(T[] a, int length, int pos) {
			unchecked {
				global::System.Array.Copy(((global::System.Array) (a) ), ((int) (( pos + 1 )) ), ((global::System.Array) (a) ), ((int) (pos) ), ((int) (( ( length - pos ) - 1 )) ));
				a[( length - 1 )] = default(T);
			}
		}
		
		
		public static void insert<T>(ref T[] a, int length, int pos, T x) {
			unchecked {
				int capacity = ( a as global::System.Array ).Length;
				if (( pos == length )) {
					if (( capacity == length )) {
						T[] newarr = new T[( (( length << 1 )) + 1 )];
						( a as global::System.Array ).CopyTo(((global::System.Array) (newarr) ), ((int) (0) ));
						a = ((T[]) (newarr) );
					}
					
				}
				else if (( pos == 0 )) {
					if (( capacity == length )) {
						T[] newarr1 = new T[( (( length << 1 )) + 1 )];
						global::System.Array.Copy(((global::System.Array) (a) ), ((int) (0) ), ((global::System.Array) (newarr1) ), ((int) (1) ), ((int) (length) ));
						a = ((T[]) (newarr1) );
					}
					else {
						global::System.Array.Copy(((global::System.Array) (a) ), ((int) (0) ), ((global::System.Array) (a) ), ((int) (1) ), ((int) (length) ));
					}
					
				}
				else if (( capacity == length )) {
					T[] newarr2 = new T[( (( length << 1 )) + 1 )];
					global::System.Array.Copy(((global::System.Array) (a) ), ((int) (0) ), ((global::System.Array) (newarr2) ), ((int) (0) ), ((int) (pos) ));
					global::System.Array.Copy(((global::System.Array) (a) ), ((int) (pos) ), ((global::System.Array) (newarr2) ), ((int) (( pos + 1 )) ), ((int) (( length - pos )) ));
					a = ((T[]) (newarr2) );
				}
				else {
					global::System.Array.Copy(((global::System.Array) (a) ), ((int) (pos) ), ((global::System.Array) (a) ), ((int) (( pos + 1 )) ), ((int) (( length - pos )) ));
					global::System.Array.Copy(((global::System.Array) (a) ), ((int) (0) ), ((global::System.Array) (a) ), ((int) (0) ), ((int) (pos) ));
				}
				
				a[pos] = x;
			}
		}
		
		
		public static global::haxe.lang.FieldHashConflict getHashConflict(global::haxe.lang.FieldHashConflict head, int hash, string name) {
			while (( head != null )) {
				if (( ( head.hash == hash ) && string.Equals(head.name, name) )) {
					return head;
				}
				
				head = head.next;
			}
			
			return null;
		}
		
		
		public static void setHashConflict(ref global::haxe.lang.FieldHashConflict head, int hash, string name, object @value) {
			global::haxe.lang.FieldHashConflict node = head;
			while (( node != null )) {
				if (( ( node.hash == hash ) && string.Equals(node.name, name) )) {
					node.@value = @value;
					return;
				}
				
				node = ((global::haxe.lang.FieldHashConflict) (node.next) );
			}
			
			head = ((global::haxe.lang.FieldHashConflict) (new global::haxe.lang.FieldHashConflict(hash, name, @value, ((global::haxe.lang.FieldHashConflict) (head) ))) );
		}
		
		
		public static bool deleteHashConflict(ref global::haxe.lang.FieldHashConflict head, int hash, string name) {
			if (( head == null )) {
				return false;
			}
			
			if (( ( head.hash == hash ) && string.Equals(head.name, name) )) {
				head = ((global::haxe.lang.FieldHashConflict) (head.next) );
				return true;
			}
			
			global::haxe.lang.FieldHashConflict prev = head;
			global::haxe.lang.FieldHashConflict node = head.next;
			while (( node != null )) {
				if (( ( node.hash == hash ) && string.Equals(node.name, name) )) {
					prev.next = node.next;
					return true;
				}
				
				node = node.next;
			}
			
			return false;
		}
		
		
		public static void addHashConflictNames(global::haxe.lang.FieldHashConflict head, global::ArrayHaxe<object> arr) {
			while (( head != null )) {
				arr.push(head.name);
				head = head.next;
			}
			
		}
		
		
	}
}


