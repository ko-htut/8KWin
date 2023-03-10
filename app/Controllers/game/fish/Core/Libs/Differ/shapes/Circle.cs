// Generated by Haxe 3.4.4

#pragma warning disable 109, 114, 219, 429, 168, 162
namespace differ.shapes {
	public class Circle : global::differ.shapes.Shape {
		
		public Circle(global::haxe.lang.EmptyObject empty) : base(global::haxe.lang.EmptyObject.EMPTY) {
		}
		
		
		public Circle(double x, double y, double radius) : base(global::haxe.lang.EmptyObject.EMPTY) {
			global::differ.shapes.Circle.__hx_ctor_differ_shapes_Circle(this, x, y, radius);
		}
		
		
		public static void __hx_ctor_differ_shapes_Circle(global::differ.shapes.Circle __hx_this, double x, double y, double radius) {
			global::differ.shapes.Shape.__hx_ctor_differ_shapes_Shape(__hx_this, x, y);
			__hx_this._radius = radius;
			__hx_this.name = global::haxe.lang.Runtime.concat("circle ", global::haxe.lang.Runtime.toString(__hx_this._radius));
		}
		
		
		
		
		
		
		public double _radius;
		
		public override global::differ.data.ShapeCollision test(global::differ.shapes.Shape shape, global::differ.data.ShapeCollision @into) {
			return shape.testCircle(this, @into, new global::haxe.lang.Null<bool>(true, true));
		}
		
		
		public override global::differ.data.ShapeCollision testCircle(global::differ.shapes.Circle circle, global::differ.data.ShapeCollision @into, global::haxe.lang.Null<bool> flip) {
			bool __temp_flip22 = ( ( ! (flip.hasValue) ) ? (false) : ((flip).@value) );
			return global::differ.sat.SAT2D.testCircleVsCircle(this, circle, @into, new global::haxe.lang.Null<bool>(__temp_flip22, true));
		}
		
		
		public override global::differ.data.ShapeCollision testPolygon(global::differ.shapes.Polygon polygon, global::differ.data.ShapeCollision @into, global::haxe.lang.Null<bool> flip) {
			bool __temp_flip23 = ( ( ! (flip.hasValue) ) ? (false) : ((flip).@value) );
			return global::differ.sat.SAT2D.testCircleVsPolygon(this, polygon, @into, new global::haxe.lang.Null<bool>(__temp_flip23, true));
		}
		
		
		public override global::differ.data.RayCollision testRay(global::differ.shapes.Ray ray, global::differ.data.RayCollision @into) {
			return global::differ.sat.SAT2D.testRayVsCircle(ray, this, @into);
		}
		
		
		public virtual double get_radius() {
			return this._radius;
		}
		
		
		public virtual double get_transformedRadius() {
			return ( this._radius * this.get_scaleX() );
		}
		
		
		public override double __hx_setField_f(string field, int hash, double @value, bool handleProperties) {
			unchecked {
				switch (hash) {
					case 527294961:
					{
						this._radius = ((double) (@value) );
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
					case 527294961:
					{
						this._radius = ((double) (global::haxe.lang.Runtime.toDouble(@value)) );
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
					case 828582484:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "get_transformedRadius", 828582484)) );
					}
					
					
					case 561922075:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "get_radius", 561922075)) );
					}
					
					
					case 1036338360:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "testRay", 1036338360)) );
					}
					
					
					case 1331294280:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "testPolygon", 1331294280)) );
					}
					
					
					case 1862383618:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "testCircle", 1862383618)) );
					}
					
					
					case 1291438162:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "test", 1291438162)) );
					}
					
					
					case 527294961:
					{
						return this._radius;
					}
					
					
					case 850732925:
					{
						return this.get_transformedRadius();
					}
					
					
					case 821481554:
					{
						return this.get_radius();
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
					case 527294961:
					{
						return this._radius;
					}
					
					
					case 850732925:
					{
						return this.get_transformedRadius();
					}
					
					
					case 821481554:
					{
						return this.get_radius();
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
					case 1291438162:
					case 1862383618:
					case 1331294280:
					case 1036338360:
					{
						return global::haxe.lang.Runtime.slowCallField(this, field, dynargs);
					}
					
					
					case 828582484:
					{
						return this.get_transformedRadius();
					}
					
					
					case 561922075:
					{
						return this.get_radius();
					}
					
					
					default:
					{
						return base.__hx_invokeField(field, hash, dynargs);
					}
					
				}
				
			}
		}
		
		
		public override void __hx_getFields(global::ArrayHaxe<object> baseArr) {
			baseArr.push("_radius");
			baseArr.push("transformedRadius");
			baseArr.push("radius");
			base.__hx_getFields(baseArr);
		}
		
		
	}
}


