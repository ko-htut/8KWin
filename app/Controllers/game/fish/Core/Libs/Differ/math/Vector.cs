// Generated by Haxe 3.4.4

#pragma warning disable 109, 114, 219, 429, 168, 162
namespace differ.math {
	public class Vector : global::haxe.lang.HxObject {
		
		public Vector(global::haxe.lang.EmptyObject empty) {
		}
		
		
		public Vector(global::haxe.lang.Null<double> _x, global::haxe.lang.Null<double> _y) {
			global::differ.math.Vector.__hx_ctor_differ_math_Vector(this, _x, _y);
		}
		
		
		public static void __hx_ctor_differ_math_Vector(global::differ.math.Vector __hx_this, global::haxe.lang.Null<double> _x, global::haxe.lang.Null<double> _y) {
			__hx_this.y = ((double) (((int) (0) )) );
			__hx_this.x = ((double) (((int) (0) )) );
			double __temp__y15 = ( ( ! (_y.hasValue) ) ? (((double) (0) )) : ((_y).@value) );
			double __temp__x14 = ( ( ! (_x.hasValue) ) ? (((double) (0) )) : ((_x).@value) );
			__hx_this.x = __temp__x14;
			__hx_this.y = __temp__y15;
		}
		
		
		public double x;
		
		public double y;
		
		
		
		
		
		public global::differ.math.Vector clone() {
			return new global::differ.math.Vector(new global::haxe.lang.Null<double>(this.x, true), new global::haxe.lang.Null<double>(this.y, true));
		}
		
		
		public virtual global::differ.math.Vector transform(global::differ.math.Matrix matrix) {
			global::differ.math.Vector v = new global::differ.math.Vector(new global::haxe.lang.Null<double>(this.x, true), new global::haxe.lang.Null<double>(this.y, true));
			v.x = ( ( ( this.x * matrix.a ) + ( this.y * matrix.c ) ) + matrix.tx );
			v.y = ( ( ( this.x * matrix.b ) + ( this.y * matrix.d ) ) + matrix.ty );
			return v;
		}
		
		
		public virtual global::differ.math.Vector normalize() {
			unchecked {
				if (( global::System.Math.Sqrt(((double) (( ( this.x * this.x ) + ( this.y * this.y ) )) )) == 0 )) {
					this.x = ((double) (1) );
					return this;
				}
				
				double len = global::System.Math.Sqrt(((double) (( ( this.x * this.x ) + ( this.y * this.y ) )) ));
				this.x /= len;
				this.y /= len;
				return this;
			}
		}
		
		
		public virtual global::differ.math.Vector truncate(double max) {
			{
				double @value = global::System.Math.Min(((double) (max) ), ((double) (global::System.Math.Sqrt(((double) (( ( this.x * this.x ) + ( this.y * this.y ) )) ))) ));
				double ep = 0.00000001;
				double _angle = global::System.Math.Atan2(((double) (this.y) ), ((double) (this.x) ));
				this.x = ( global::System.Math.Cos(((double) (_angle) )) * @value );
				this.y = ( global::System.Math.Sin(((double) (_angle) )) * @value );
				if (( global::System.Math.Abs(((double) (this.x) )) < ep )) {
					this.x = ((double) (0) );
				}
				
				if (( global::System.Math.Abs(((double) (this.y) )) < ep )) {
					this.y = ((double) (0) );
				}
				
			}
			
			return this;
		}
		
		
		public virtual global::differ.math.Vector invert() {
			this.x =  - (this.x) ;
			this.y =  - (this.y) ;
			return this;
		}
		
		
		public virtual double dot(global::differ.math.Vector other) {
			return ( ( this.x * other.x ) + ( this.y * other.y ) );
		}
		
		
		public virtual double cross(global::differ.math.Vector other) {
			return ( ( this.x * other.y ) - ( this.y * other.x ) );
		}
		
		
		public virtual global::differ.math.Vector @add(global::differ.math.Vector other) {
			this.x += other.x;
			this.y += other.y;
			return this;
		}
		
		
		public virtual global::differ.math.Vector subtract(global::differ.math.Vector other) {
			this.x -= other.x;
			this.y -= other.y;
			return this;
		}
		
		
		public virtual string toString() {
			return global::haxe.lang.Runtime.concat(global::haxe.lang.Runtime.concat(global::haxe.lang.Runtime.concat("Vector x:", global::haxe.lang.Runtime.toString(this.x)), ", y:"), global::haxe.lang.Runtime.toString(this.y));
		}
		
		
		public double set_length(double @value) {
			double ep = 0.00000001;
			double _angle = global::System.Math.Atan2(((double) (this.y) ), ((double) (this.x) ));
			this.x = ( global::System.Math.Cos(((double) (_angle) )) * @value );
			this.y = ( global::System.Math.Sin(((double) (_angle) )) * @value );
			if (( global::System.Math.Abs(((double) (this.x) )) < ep )) {
				this.x = ((double) (0) );
			}
			
			if (( global::System.Math.Abs(((double) (this.y) )) < ep )) {
				this.y = ((double) (0) );
			}
			
			return @value;
		}
		
		
		public double get_length() {
			return global::System.Math.Sqrt(((double) (( ( this.x * this.x ) + ( this.y * this.y ) )) ));
		}
		
		
		public double get_lengthsq() {
			return ( ( this.x * this.x ) + ( this.y * this.y ) );
		}
		
		
		public override double __hx_setField_f(string field, int hash, double @value, bool handleProperties) {
			unchecked {
				switch (hash) {
					case 520590566:
					{
						this.set_length(@value);
						return @value;
					}
					
					
					case 121:
					{
						this.y = ((double) (@value) );
						return @value;
					}
					
					
					case 120:
					{
						this.x = ((double) (@value) );
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
					case 520590566:
					{
						this.set_length(((double) (global::haxe.lang.Runtime.toDouble(@value)) ));
						return @value;
					}
					
					
					case 121:
					{
						this.y = ((double) (global::haxe.lang.Runtime.toDouble(@value)) );
						return @value;
					}
					
					
					case 120:
					{
						this.x = ((double) (global::haxe.lang.Runtime.toDouble(@value)) );
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
					case 1423782669:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "get_lengthsq", 1423782669)) );
					}
					
					
					case 261031087:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "get_length", 261031087)) );
					}
					
					
					case 319595299:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "set_length", 319595299)) );
					}
					
					
					case 946786476:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "toString", 946786476)) );
					}
					
					
					case 2014410004:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "subtract", 2014410004)) );
					}
					
					
					case 4846113:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "add", 4846113)) );
					}
					
					
					case 1280991104:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "cross", 1280991104)) );
					}
					
					
					case 4997769:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "dot", 4997769)) );
					}
					
					
					case 534308630:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "invert", 534308630)) );
					}
					
					
					case 1324990054:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "truncate", 1324990054)) );
					}
					
					
					case 731985805:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "normalize", 731985805)) );
					}
					
					
					case 1167273324:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "transform", 1167273324)) );
					}
					
					
					case 1214452573:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "clone", 1214452573)) );
					}
					
					
					case 532905732:
					{
						return this.get_lengthsq();
					}
					
					
					case 520590566:
					{
						return this.get_length();
					}
					
					
					case 121:
					{
						return this.y;
					}
					
					
					case 120:
					{
						return this.x;
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
					case 532905732:
					{
						return this.get_lengthsq();
					}
					
					
					case 520590566:
					{
						return this.get_length();
					}
					
					
					case 121:
					{
						return this.y;
					}
					
					
					case 120:
					{
						return this.x;
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
					case 1423782669:
					{
						return this.get_lengthsq();
					}
					
					
					case 261031087:
					{
						return this.get_length();
					}
					
					
					case 319595299:
					{
						return this.set_length(((double) (global::haxe.lang.Runtime.toDouble(dynargs[0])) ));
					}
					
					
					case 946786476:
					{
						return this.toString();
					}
					
					
					case 2014410004:
					{
						return this.subtract(((global::differ.math.Vector) (dynargs[0]) ));
					}
					
					
					case 4846113:
					{
						return this.@add(((global::differ.math.Vector) (dynargs[0]) ));
					}
					
					
					case 1280991104:
					{
						return this.cross(((global::differ.math.Vector) (dynargs[0]) ));
					}
					
					
					case 4997769:
					{
						return this.dot(((global::differ.math.Vector) (dynargs[0]) ));
					}
					
					
					case 534308630:
					{
						return this.invert();
					}
					
					
					case 1324990054:
					{
						return this.truncate(((double) (global::haxe.lang.Runtime.toDouble(dynargs[0])) ));
					}
					
					
					case 731985805:
					{
						return this.normalize();
					}
					
					
					case 1167273324:
					{
						return this.transform(((global::differ.math.Matrix) (dynargs[0]) ));
					}
					
					
					case 1214452573:
					{
						return this.clone();
					}
					
					
					default:
					{
						return base.__hx_invokeField(field, hash, dynargs);
					}
					
				}
				
			}
		}
		
		
		public override void __hx_getFields(global::ArrayHaxe<object> baseArr) {
			baseArr.push("lengthsq");
			baseArr.push("length");
			baseArr.push("y");
			baseArr.push("x");
			base.__hx_getFields(baseArr);
		}
		
		
		public override string ToString(){
			return this.toString();
		}
		
		
	}
}


