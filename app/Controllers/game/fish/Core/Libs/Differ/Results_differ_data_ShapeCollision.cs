// Generated by Haxe 3.4.4

#pragma warning disable 109, 114, 219, 429, 168, 162
namespace differ {
	public class Results_differ_data_ShapeCollision : global::haxe.lang.HxObject {
		
		public Results_differ_data_ShapeCollision(global::haxe.lang.EmptyObject empty) {
		}
		
		
		public Results_differ_data_ShapeCollision(int size) {
			global::differ.Results_differ_data_ShapeCollision.__hx_ctor_differ_Results_differ_data_ShapeCollision(this, size);
		}
		
		
		public static void __hx_ctor_differ_Results_differ_data_ShapeCollision(global::differ.Results_differ_data_ShapeCollision __hx_this, int size) {
			__hx_this.count = 0;
			global::ArrayHaxe<object> _g = new global::ArrayHaxe<object>(new object[]{});
			{
				int _g2 = 0;
				int _g1 = size;
				while (( _g2 < _g1 )) {
					int i = _g2++;
					_g.push(new global::differ.data.ShapeCollision());
				}
				
			}
			
			__hx_this.items = _g;
		}
		
		
		
		
		
		
		public global::ArrayHaxe<object> items;
		
		public int count;
		
		public void push(global::differ.data.ShapeCollision @value) {
			this.items[this.count] = @value;
			this.count++;
		}
		
		
		public global::differ.data.ShapeCollision @get(int index) {
			unchecked {
				if (( ( index < 0 ) && ( index > ( this.count - 1 ) ) )) {
					return null;
				}
				
				return ((global::differ.data.ShapeCollision) (this.items[index]) );
			}
		}
		
		
		public global::differ.data.ShapeCollision pull() {
			if (( this.items.length == this.count )) {
				this.items.push(new global::differ.data.ShapeCollision());
			}
			
			return ((global::differ.data.ShapeCollision) (this.items[this.count]) );
		}
		
		
		public global::differ.Results_differ_data_ShapeCollision clear() {
			this.count = 0;
			return this;
		}
		
		
		public global::differ.ResultsIterator_differ_data_ShapeCollision iterator() {
			return new global::differ.ResultsIterator_differ_data_ShapeCollision(((global::differ.Results_differ_data_ShapeCollision) (this) ));
		}
		
		
		public int get_length() {
			return this.count;
		}
		
		
		public int get_total() {
			return this.items.length;
		}
		
		
		public override double __hx_setField_f(string field, int hash, double @value, bool handleProperties) {
			unchecked {
				switch (hash) {
					case 1248019663:
					{
						this.count = ((int) (@value) );
						return @value;
					}
					
					
					default:
					{
						return base.__hx_setField_f(field, hash, @value, handleProperties);
					}
					
				}
				
			}
		}
		
		
		public override object __hx_setField(string field, int hash, object @value, bool handleProperties) {
			unchecked {
				switch (hash) {
					case 1248019663:
					{
						this.count = ((int) (global::haxe.lang.Runtime.toInt(@value)) );
						return @value;
					}
					
					
					case 1108126720:
					{
						this.items = ((global::ArrayHaxe<object>) (global::ArrayHaxe<object>.__hx_cast<object>(((global::ArrayHaxe) (@value) ))) );
						return @value;
					}
					
					
					default:
					{
						return base.__hx_setField(field, hash, @value, handleProperties);
					}
					
				}
				
			}
		}
		
		
		public override object __hx_getField(string field, int hash, bool throwErrors, bool isCheck, bool handleProperties) {
			unchecked {
				switch (hash) {
					case 1474015259:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "get_total", 1474015259)) );
					}
					
					
					case 261031087:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "get_length", 261031087)) );
					}
					
					
					case 328878574:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "iterator", 328878574)) );
					}
					
					
					case 1213952397:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "clear", 1213952397)) );
					}
					
					
					case 1247873989:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "pull", 1247873989)) );
					}
					
					
					case 5144726:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "get", 5144726)) );
					}
					
					
					case 1247875546:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "push", 1247875546)) );
					}
					
					
					case 1248019663:
					{
						return this.count;
					}
					
					
					case 1108126720:
					{
						return this.items;
					}
					
					
					case 338842564:
					{
						return this.get_total();
					}
					
					
					case 520590566:
					{
						return this.get_length();
					}
					
					
					default:
					{
						return base.__hx_getField(field, hash, throwErrors, isCheck, handleProperties);
					}
					
				}
				
			}
		}
		
		
		public override double __hx_getField_f(string field, int hash, bool throwErrors, bool handleProperties) {
			unchecked {
				switch (hash) {
					case 1248019663:
					{
						return ((double) (this.count) );
					}
					
					
					case 338842564:
					{
						return ((double) (this.get_total()) );
					}
					
					
					case 520590566:
					{
						return ((double) (this.get_length()) );
					}
					
					
					default:
					{
						return base.__hx_getField_f(field, hash, throwErrors, handleProperties);
					}
					
				}
				
			}
		}
		
		
		public override object __hx_invokeField(string field, int hash, global::ArrayHaxe dynargs) {
			unchecked {
				switch (hash) {
					case 1474015259:
					{
						return this.get_total();
					}
					
					
					case 261031087:
					{
						return this.get_length();
					}
					
					
					case 328878574:
					{
						return this.iterator();
					}
					
					
					case 1213952397:
					{
						return this.clear();
					}
					
					
					case 1247873989:
					{
						return this.pull();
					}
					
					
					case 5144726:
					{
						return this.@get(((int) (global::haxe.lang.Runtime.toInt(dynargs[0])) ));
					}
					
					
					case 1247875546:
					{
						this.push(((global::differ.data.ShapeCollision) (dynargs[0]) ));
						break;
					}
					
					
					default:
					{
						return base.__hx_invokeField(field, hash, dynargs);
					}
					
				}
				
				return null;
			}
		}
		
		
		public override void __hx_getFields(global::ArrayHaxe<object> baseArr) {
			baseArr.push("count");
			baseArr.push("items");
			baseArr.push("total");
			baseArr.push("length");
			base.__hx_getFields(baseArr);
		}
		
		
	}
}


