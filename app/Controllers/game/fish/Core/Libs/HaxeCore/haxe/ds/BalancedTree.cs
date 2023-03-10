// Generated by Haxe 3.4.4

#pragma warning disable 109, 114, 219, 429, 168, 162
namespace haxe.ds {
	public class BalancedTree<K, V> : global::haxe.lang.HxObject, global::haxe.ds.BalancedTree {
		
		public BalancedTree(global::haxe.lang.EmptyObject empty) {
		}
		
		
		public BalancedTree() {
			global::haxe.ds.BalancedTree<object, object>.__hx_ctor_haxe_ds_BalancedTree<K, V>(((global::haxe.ds.BalancedTree<K, V>) (this) ));
		}
		
		
		public static void __hx_ctor_haxe_ds_BalancedTree<K_c, V_c>(global::haxe.ds.BalancedTree<K_c, V_c> __hx_this) {
		}
		
		
		public static object __hx_cast<K_c_c, V_c_c>(global::haxe.ds.BalancedTree me) {
			return ( (( me != null )) ? (me.haxe_ds_BalancedTree_cast<K_c_c, V_c_c>()) : default(object) );
		}
		
		
		public virtual object haxe_ds_BalancedTree_cast<K_c, V_c>() {
			if (( global::haxe.lang.Runtime.eq(typeof(K), typeof(K_c)) && global::haxe.lang.Runtime.eq(typeof(V), typeof(V_c)) )) {
				return this;
			}
			
			global::haxe.ds.BalancedTree<K_c, V_c> new_me = new global::haxe.ds.BalancedTree<K_c, V_c>(global::haxe.lang.EmptyObject.EMPTY);
			global::ArrayHaxe<object> fields = global::ReflectHaxe.fields(this);
			int i = 0;
			while (( i < fields.length )) {
				string field = global::haxe.lang.Runtime.toString(fields[i++]);
				global::ReflectHaxe.setField(new_me, field, global::ReflectHaxe.field(this, field));
			}
			
			return new_me;
		}
		
		
		public global::haxe.ds.TreeNode<K, V> root;
		
		public virtual void @set(K key, V @value) {
			this.root = this.setLoop(key, @value, this.root);
		}
		
		
		public virtual global::haxe.lang.Null<V> @get(K key) {
			global::haxe.ds.TreeNode<K, V> node = this.root;
			while (( node != null )) {
				int c = this.compare(key, node.key);
				if (( c == 0 )) {
					return new global::haxe.lang.Null<V>(node.@value, true);
				}
				
				if (( c < 0 )) {
					node = node.left;
				}
				else {
					node = node.right;
				}
				
			}
			
			return default(global::haxe.lang.Null<V>);
		}
		
		
		public virtual bool @remove(K key) {
			try {
				this.root = this.removeLoop(key, this.root);
				return true;
			}
			catch (global::System.Exception __temp_catchallException1){
				global::haxe.lang.Exceptions.exception = __temp_catchallException1;
				object __temp_catchall2 = __temp_catchallException1;
				if (( __temp_catchall2 is global::haxe.lang.HaxeException )) {
					__temp_catchall2 = ((global::haxe.lang.HaxeException) (__temp_catchallException1) ).obj;
				}
				
				if (( __temp_catchall2 is string )) {
					string e = global::haxe.lang.Runtime.toString(__temp_catchall2);
					{
						return false;
					}
					
				}
				else {
					throw;
				}
				
			}
			
			
			return default(bool);
		}
		
		
		public virtual bool exists(K key) {
			global::haxe.ds.TreeNode<K, V> node = this.root;
			while (( node != null )) {
				int c = this.compare(key, node.key);
				if (( c == 0 )) {
					return true;
				}
				else if (( c < 0 )) {
					node = node.left;
				}
				else {
					node = node.right;
				}
				
			}
			
			return false;
		}
		
		
		public virtual object iterator() {
			global::ArrayHaxe<V> ret = new global::ArrayHaxe<V>(new V[]{});
			this.iteratorLoop(this.root, ret);
			return ((object) (new global::_Array.ArrayIterator<V>(((global::ArrayHaxe<V>) (ret) ))) );
		}
		
		
		public virtual object keys() {
			global::ArrayHaxe<K> ret = new global::ArrayHaxe<K>(new K[]{});
			this.keysLoop(this.root, ret);
			return ((object) (new global::_Array.ArrayIterator<K>(((global::ArrayHaxe<K>) (ret) ))) );
		}
		
		
		public virtual global::haxe.ds.TreeNode<K, V> setLoop(K k, V v, global::haxe.ds.TreeNode<K, V> node) {
			if (( node == null )) {
				return new global::haxe.ds.TreeNode<K, V>(null, k, v, null, default(global::haxe.lang.Null<int>));
			}
			
			int c = this.compare(k, node.key);
			if (( c == 0 )) {
				return new global::haxe.ds.TreeNode<K, V>(node.left, k, v, node.right, new global::haxe.lang.Null<int>(( (( node == null )) ? (0) : (node._height) ), true));
			}
			else if (( c < 0 )) {
				global::haxe.ds.TreeNode<K, V> nl = this.setLoop(k, v, node.left);
				return this.balance(nl, node.key, node.@value, node.right);
			}
			else {
				global::haxe.ds.TreeNode<K, V> nr = this.setLoop(k, v, node.right);
				return this.balance(node.left, node.key, node.@value, nr);
			}
			
		}
		
		
		public virtual global::haxe.ds.TreeNode<K, V> removeLoop(K k, global::haxe.ds.TreeNode<K, V> node) {
			if (( node == null )) {
				throw global::haxe.lang.HaxeException.wrap("Not_found");
			}
			
			int c = this.compare(k, node.key);
			if (( c == 0 )) {
				return this.merge(node.left, node.right);
			}
			else if (( c < 0 )) {
				return this.balance(this.removeLoop(k, node.left), node.key, node.@value, node.right);
			}
			else {
				return this.balance(node.left, node.key, node.@value, this.removeLoop(k, node.right));
			}
			
		}
		
		
		public virtual void iteratorLoop(global::haxe.ds.TreeNode<K, V> node, global::ArrayHaxe<V> acc) {
			if (( node != null )) {
				this.iteratorLoop(node.left, acc);
				acc.push(node.@value);
				this.iteratorLoop(node.right, acc);
			}
			
		}
		
		
		public virtual void keysLoop(global::haxe.ds.TreeNode<K, V> node, global::ArrayHaxe<K> acc) {
			if (( node != null )) {
				this.keysLoop(node.left, acc);
				acc.push(node.key);
				this.keysLoop(node.right, acc);
			}
			
		}
		
		
		public virtual global::haxe.ds.TreeNode<K, V> merge(global::haxe.ds.TreeNode<K, V> t1, global::haxe.ds.TreeNode<K, V> t2) {
			if (( t1 == null )) {
				return t2;
			}
			
			if (( t2 == null )) {
				return t1;
			}
			
			global::haxe.ds.TreeNode<K, V> t = this.minBinding(t2);
			return this.balance(t1, t.key, t.@value, this.removeMinBinding(t2));
		}
		
		
		public virtual global::haxe.ds.TreeNode<K, V> minBinding(global::haxe.ds.TreeNode<K, V> t) {
			if (( t == null )) {
				throw global::haxe.lang.HaxeException.wrap("Not_found");
			}
			else if (( t.left == null )) {
				return t;
			}
			else {
				return this.minBinding(t.left);
			}
			
		}
		
		
		public virtual global::haxe.ds.TreeNode<K, V> removeMinBinding(global::haxe.ds.TreeNode<K, V> t) {
			if (( t.left == null )) {
				return t.right;
			}
			else {
				return this.balance(this.removeMinBinding(t.left), t.key, t.@value, t.right);
			}
			
		}
		
		
		public virtual global::haxe.ds.TreeNode<K, V> balance(global::haxe.ds.TreeNode<K, V> l, K k, V v, global::haxe.ds.TreeNode<K, V> r) {
			unchecked {
				int hl = ( (( l == null )) ? (0) : (l._height) );
				int hr = ( (( r == null )) ? (0) : (r._height) );
				if (( hl > ( hr + 2 ) )) {
					global::haxe.ds.TreeNode<K, V> _this = l.left;
					global::haxe.ds.TreeNode<K, V> _this1 = l.right;
					if (( (( (( _this == null )) ? (0) : (_this._height) )) >= (( (( _this1 == null )) ? (0) : (_this1._height) )) )) {
						return new global::haxe.ds.TreeNode<K, V>(l.left, l.key, l.@value, new global::haxe.ds.TreeNode<K, V>(l.right, k, v, r, default(global::haxe.lang.Null<int>)), default(global::haxe.lang.Null<int>));
					}
					else {
						return new global::haxe.ds.TreeNode<K, V>(new global::haxe.ds.TreeNode<K, V>(l.left, l.key, l.@value, l.right.left, default(global::haxe.lang.Null<int>)), l.right.key, l.right.@value, new global::haxe.ds.TreeNode<K, V>(l.right.right, k, v, r, default(global::haxe.lang.Null<int>)), default(global::haxe.lang.Null<int>));
					}
					
				}
				else if (( hr > ( hl + 2 ) )) {
					global::haxe.ds.TreeNode<K, V> _this2 = r.right;
					global::haxe.ds.TreeNode<K, V> _this3 = r.left;
					if (( (( (( _this2 == null )) ? (0) : (_this2._height) )) > (( (( _this3 == null )) ? (0) : (_this3._height) )) )) {
						return new global::haxe.ds.TreeNode<K, V>(new global::haxe.ds.TreeNode<K, V>(l, k, v, r.left, default(global::haxe.lang.Null<int>)), r.key, r.@value, r.right, default(global::haxe.lang.Null<int>));
					}
					else {
						return new global::haxe.ds.TreeNode<K, V>(new global::haxe.ds.TreeNode<K, V>(l, k, v, r.left.left, default(global::haxe.lang.Null<int>)), r.left.key, r.left.@value, new global::haxe.ds.TreeNode<K, V>(r.left.right, r.key, r.@value, r.right, default(global::haxe.lang.Null<int>)), default(global::haxe.lang.Null<int>));
					}
					
				}
				else {
					return new global::haxe.ds.TreeNode<K, V>(l, k, v, r, new global::haxe.lang.Null<int>(( (( (( hl > hr )) ? (hl) : (hr) )) + 1 ), true));
				}
				
			}
		}
		
		
		public virtual int compare(K k1, K k2) {
			return global::ReflectHaxe.compare<K>(global::haxe.lang.Runtime.genericCast<K>(k1), global::haxe.lang.Runtime.genericCast<K>(k2));
		}
		
		
		public virtual string toString() {
			if (( this.root == null )) {
				return "{}";
			}
			else {
				return global::haxe.lang.Runtime.concat(global::haxe.lang.Runtime.concat("{", this.root.toString()), "}");
			}
			
		}
		
		
		public override object __hx_setField(string field, int hash, object @value, bool handleProperties) {
			unchecked {
				switch (hash) {
					case 1269755426:
					{
						this.root = ((global::haxe.ds.TreeNode<K, V>) (global::haxe.ds.TreeNode<object, object>.__hx_cast<K, V>(((global::haxe.ds.TreeNode) (@value) ))) );
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
					case 946786476:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "toString", 946786476)) );
					}
					
					
					case 57219237:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "compare", 57219237)) );
					}
					
					
					case 596483356:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "balance", 596483356)) );
					}
					
					
					case 2123232567:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "removeMinBinding", 2123232567)) );
					}
					
					
					case 1155848147:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "minBinding", 1155848147)) );
					}
					
					
					case 96903864:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "merge", 96903864)) );
					}
					
					
					case 451001976:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "keysLoop", 451001976)) );
					}
					
					
					case 1692511090:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "iteratorLoop", 1692511090)) );
					}
					
					
					case 1154932936:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "removeLoop", 1154932936)) );
					}
					
					
					case 222029606:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "setLoop", 222029606)) );
					}
					
					
					case 1191633396:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "keys", 1191633396)) );
					}
					
					
					case 328878574:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "iterator", 328878574)) );
					}
					
					
					case 1071652316:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "exists", 1071652316)) );
					}
					
					
					case 76061764:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "remove", 76061764)) );
					}
					
					
					case 5144726:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "get", 5144726)) );
					}
					
					
					case 5741474:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "set", 5741474)) );
					}
					
					
					case 1269755426:
					{
						return this.root;
					}
					
					
					default:
					{
						return base.__hx_getField(field, hash, throwErrors, isCheck, handleProperties);
					}
					
				}
				
			}
		}
		
		
		public override object __hx_invokeField(string field, int hash, global::ArrayHaxe dynargs) {
			unchecked {
				switch (hash) {
					case 946786476:
					{
						return this.toString();
					}
					
					
					case 57219237:
					{
						return this.compare(global::haxe.lang.Runtime.genericCast<K>(dynargs[0]), global::haxe.lang.Runtime.genericCast<K>(dynargs[1]));
					}
					
					
					case 596483356:
					{
						return this.balance(((global::haxe.ds.TreeNode<K, V>) (global::haxe.ds.TreeNode<object, object>.__hx_cast<K, V>(((global::haxe.ds.TreeNode) (dynargs[0]) ))) ), global::haxe.lang.Runtime.genericCast<K>(dynargs[1]), global::haxe.lang.Runtime.genericCast<V>(dynargs[2]), ((global::haxe.ds.TreeNode<K, V>) (global::haxe.ds.TreeNode<object, object>.__hx_cast<K, V>(((global::haxe.ds.TreeNode) (dynargs[3]) ))) ));
					}
					
					
					case 2123232567:
					{
						return this.removeMinBinding(((global::haxe.ds.TreeNode<K, V>) (global::haxe.ds.TreeNode<object, object>.__hx_cast<K, V>(((global::haxe.ds.TreeNode) (dynargs[0]) ))) ));
					}
					
					
					case 1155848147:
					{
						return this.minBinding(((global::haxe.ds.TreeNode<K, V>) (global::haxe.ds.TreeNode<object, object>.__hx_cast<K, V>(((global::haxe.ds.TreeNode) (dynargs[0]) ))) ));
					}
					
					
					case 96903864:
					{
						return this.merge(((global::haxe.ds.TreeNode<K, V>) (global::haxe.ds.TreeNode<object, object>.__hx_cast<K, V>(((global::haxe.ds.TreeNode) (dynargs[0]) ))) ), ((global::haxe.ds.TreeNode<K, V>) (global::haxe.ds.TreeNode<object, object>.__hx_cast<K, V>(((global::haxe.ds.TreeNode) (dynargs[1]) ))) ));
					}
					
					
					case 451001976:
					{
						this.keysLoop(((global::haxe.ds.TreeNode<K, V>) (global::haxe.ds.TreeNode<object, object>.__hx_cast<K, V>(((global::haxe.ds.TreeNode) (dynargs[0]) ))) ), ((global::ArrayHaxe<K>) (global::ArrayHaxe<object>.__hx_cast<K>(((global::ArrayHaxe) (dynargs[1]) ))) ));
						break;
					}
					
					
					case 1692511090:
					{
						this.iteratorLoop(((global::haxe.ds.TreeNode<K, V>) (global::haxe.ds.TreeNode<object, object>.__hx_cast<K, V>(((global::haxe.ds.TreeNode) (dynargs[0]) ))) ), ((global::ArrayHaxe<V>) (global::ArrayHaxe<object>.__hx_cast<V>(((global::ArrayHaxe) (dynargs[1]) ))) ));
						break;
					}
					
					
					case 1154932936:
					{
						return this.removeLoop(global::haxe.lang.Runtime.genericCast<K>(dynargs[0]), ((global::haxe.ds.TreeNode<K, V>) (global::haxe.ds.TreeNode<object, object>.__hx_cast<K, V>(((global::haxe.ds.TreeNode) (dynargs[1]) ))) ));
					}
					
					
					case 222029606:
					{
						return this.setLoop(global::haxe.lang.Runtime.genericCast<K>(dynargs[0]), global::haxe.lang.Runtime.genericCast<V>(dynargs[1]), ((global::haxe.ds.TreeNode<K, V>) (global::haxe.ds.TreeNode<object, object>.__hx_cast<K, V>(((global::haxe.ds.TreeNode) (dynargs[2]) ))) ));
					}
					
					
					case 1191633396:
					{
						return this.keys();
					}
					
					
					case 328878574:
					{
						return this.iterator();
					}
					
					
					case 1071652316:
					{
						return this.exists(global::haxe.lang.Runtime.genericCast<K>(dynargs[0]));
					}
					
					
					case 76061764:
					{
						return this.@remove(global::haxe.lang.Runtime.genericCast<K>(dynargs[0]));
					}
					
					
					case 5144726:
					{
						return (this.@get(global::haxe.lang.Runtime.genericCast<K>(dynargs[0]))).toDynamic();
					}
					
					
					case 5741474:
					{
						this.@set(global::haxe.lang.Runtime.genericCast<K>(dynargs[0]), global::haxe.lang.Runtime.genericCast<V>(dynargs[1]));
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
			baseArr.push("root");
			base.__hx_getFields(baseArr);
		}
		
		
		public override string ToString(){
			return this.toString();
		}
		
		
	}
}



#pragma warning disable 109, 114, 219, 429, 168, 162
namespace haxe.ds {
	[global::haxe.lang.GenericInterface(typeof(global::haxe.ds.BalancedTree<object, object>))]
	public interface BalancedTree : global::haxe.lang.IHxObject, global::haxe.lang.IGenericObject {
		
		object haxe_ds_BalancedTree_cast<K_c, V_c>();
		
		object iterator();
		
		object keys();
		
		string toString();
		
	}
}



#pragma warning disable 109, 114, 219, 429, 168, 162
namespace haxe.ds {
	public class TreeNode<K, V> : global::haxe.lang.HxObject, global::haxe.ds.TreeNode {
		
		public TreeNode(global::haxe.lang.EmptyObject empty) {
		}
		
		
		public TreeNode(global::haxe.ds.TreeNode<K, V> l, K k, V v, global::haxe.ds.TreeNode<K, V> r, global::haxe.lang.Null<int> h) {
			global::haxe.ds.TreeNode<object, object>.__hx_ctor_haxe_ds_TreeNode<K, V>(((global::haxe.ds.TreeNode<K, V>) (this) ), ((global::haxe.ds.TreeNode<K, V>) (l) ), global::haxe.lang.Runtime.genericCast<K>(k), global::haxe.lang.Runtime.genericCast<V>(v), ((global::haxe.ds.TreeNode<K, V>) (r) ), ((global::haxe.lang.Null<int>) (h) ));
		}
		
		
		public static void __hx_ctor_haxe_ds_TreeNode<K_c, V_c>(global::haxe.ds.TreeNode<K_c, V_c> __hx_this, global::haxe.ds.TreeNode<K_c, V_c> l, K_c k, V_c v, global::haxe.ds.TreeNode<K_c, V_c> r, global::haxe.lang.Null<int> h) {
			unchecked {
				int __temp_h29 = ( ( ! (h.hasValue) ) ? (-1) : ((h).@value) );
				__hx_this.left = l;
				__hx_this.key = k;
				__hx_this.@value = v;
				__hx_this.right = r;
				if (( __temp_h29 == -1 )) {
					int tmp = default(int);
					global::haxe.ds.TreeNode<K_c, V_c> _this = __hx_this.left;
					global::haxe.ds.TreeNode<K_c, V_c> _this1 = __hx_this.right;
					if (( (( (( _this == null )) ? (0) : (_this._height) )) > (( (( _this1 == null )) ? (0) : (_this1._height) )) )) {
						global::haxe.ds.TreeNode<K_c, V_c> _this2 = __hx_this.left;
						if (( _this2 == null )) {
							tmp = 0;
						}
						else {
							tmp = _this2._height;
						}
						
					}
					else {
						global::haxe.ds.TreeNode<K_c, V_c> _this3 = __hx_this.right;
						if (( _this3 == null )) {
							tmp = 0;
						}
						else {
							tmp = _this3._height;
						}
						
					}
					
					__hx_this._height = ( tmp + 1 );
				}
				else {
					__hx_this._height = __temp_h29;
				}
				
			}
		}
		
		
		public static object __hx_cast<K_c_c, V_c_c>(global::haxe.ds.TreeNode me) {
			return ( (( me != null )) ? (me.haxe_ds_TreeNode_cast<K_c_c, V_c_c>()) : default(object) );
		}
		
		
		public virtual object haxe_ds_TreeNode_cast<K_c, V_c>() {
			if (( global::haxe.lang.Runtime.eq(typeof(K), typeof(K_c)) && global::haxe.lang.Runtime.eq(typeof(V), typeof(V_c)) )) {
				return this;
			}
			
			global::haxe.ds.TreeNode<K_c, V_c> new_me = new global::haxe.ds.TreeNode<K_c, V_c>(global::haxe.lang.EmptyObject.EMPTY);
			global::ArrayHaxe<object> fields = global::ReflectHaxe.fields(this);
			int i = 0;
			while (( i < fields.length )) {
				string field = global::haxe.lang.Runtime.toString(fields[i++]);
				global::ReflectHaxe.setField(new_me, field, global::ReflectHaxe.field(this, field));
			}
			
			return new_me;
		}
		
		
		public global::haxe.ds.TreeNode<K, V> left;
		
		public global::haxe.ds.TreeNode<K, V> right;
		
		public K key;
		
		public V @value;
		
		public int _height;
		
		public virtual string toString() {
			return global::haxe.lang.Runtime.concat(global::haxe.lang.Runtime.concat((( (( this.left == null )) ? ("") : (global::haxe.lang.Runtime.concat(this.left.toString(), ", ")) )), (global::haxe.lang.Runtime.concat(global::haxe.lang.Runtime.concat(global::haxe.lang.Runtime.concat("", global::Std.@string(this.key)), "="), global::Std.@string(this.@value)))), (( (( this.right == null )) ? ("") : (global::haxe.lang.Runtime.concat(", ", this.right.toString())) )));
		}
		
		
		public override double __hx_setField_f(string field, int hash, double @value, bool handleProperties) {
			unchecked {
				switch (hash) {
					case 1891834246:
					{
						this._height = ((int) (@value) );
						return @value;
					}
					
					
					case 834174833:
					{
						this.@value = global::haxe.lang.Runtime.genericCast<V>(((object) (@value) ));
						return ((double) (global::haxe.lang.Runtime.toDouble(((object) (@value) ))) );
					}
					
					
					case 5343647:
					{
						this.key = global::haxe.lang.Runtime.genericCast<K>(((object) (@value) ));
						return ((double) (global::haxe.lang.Runtime.toDouble(((object) (@value) ))) );
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
					case 1891834246:
					{
						this._height = ((int) (global::haxe.lang.Runtime.toInt(@value)) );
						return @value;
					}
					
					
					case 834174833:
					{
						this.@value = global::haxe.lang.Runtime.genericCast<V>(@value);
						return @value;
					}
					
					
					case 5343647:
					{
						this.key = global::haxe.lang.Runtime.genericCast<K>(@value);
						return @value;
					}
					
					
					case 1768164316:
					{
						this.right = ((global::haxe.ds.TreeNode<K, V>) (global::haxe.ds.TreeNode<object, object>.__hx_cast<K, V>(((global::haxe.ds.TreeNode) (@value) ))) );
						return @value;
					}
					
					
					case 1202718727:
					{
						this.left = ((global::haxe.ds.TreeNode<K, V>) (global::haxe.ds.TreeNode<object, object>.__hx_cast<K, V>(((global::haxe.ds.TreeNode) (@value) ))) );
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
					case 946786476:
					{
						return ((global::haxe.lang.Function) (new global::haxe.lang.Closure(this, "toString", 946786476)) );
					}
					
					
					case 1891834246:
					{
						return this._height;
					}
					
					
					case 834174833:
					{
						return this.@value;
					}
					
					
					case 5343647:
					{
						return this.key;
					}
					
					
					case 1768164316:
					{
						return this.right;
					}
					
					
					case 1202718727:
					{
						return this.left;
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
					case 1891834246:
					{
						return ((double) (this._height) );
					}
					
					
					case 834174833:
					{
						return ((double) (global::haxe.lang.Runtime.toDouble(((object) (this.@value) ))) );
					}
					
					
					case 5343647:
					{
						return ((double) (global::haxe.lang.Runtime.toDouble(((object) (this.key) ))) );
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
					case 946786476:
					{
						return this.toString();
					}
					
					
					default:
					{
						return base.__hx_invokeField(field, hash, dynargs);
					}
					
				}
				
			}
		}
		
		
		public override void __hx_getFields(global::ArrayHaxe<object> baseArr) {
			baseArr.push("_height");
			baseArr.push("value");
			baseArr.push("key");
			baseArr.push("right");
			baseArr.push("left");
			base.__hx_getFields(baseArr);
		}
		
		
		public override string ToString(){
			return this.toString();
		}
		
		
	}
}



#pragma warning disable 109, 114, 219, 429, 168, 162
namespace haxe.ds {
	[global::haxe.lang.GenericInterface(typeof(global::haxe.ds.TreeNode<object, object>))]
	public interface TreeNode : global::haxe.lang.IHxObject, global::haxe.lang.IGenericObject {
		
		object haxe_ds_TreeNode_cast<K_c, V_c>();
		
		string toString();
		
	}
}


