// Generated by Haxe 3.4.4

#pragma warning disable 109, 114, 219, 429, 168, 162
namespace haxe {
	public interface IMap<K, V> : global::haxe.lang.IHxObject, global::haxe.IMap {
		
		global::haxe.lang.Null<V> @get(K k);
		
		void @set(K k, V v);
		
		bool exists(K k);
		
		bool @remove(K k);
		
	}
	public class IMap__Statics_{
		public static object __hx_cast<K_c_c, V_c_c>(global::haxe.IMap me) {
			return ( (( me != null )) ? (me.haxe_IMap_cast<K_c_c, V_c_c>()) : default(object) );
		}
		
		
	}
}



#pragma warning disable 109, 114, 219, 429, 168, 162
namespace haxe {
	[global::haxe.lang.GenericInterface(typeof(global::haxe.IMap<object, object>))]
	public interface IMap : global::haxe.lang.IHxObject, global::haxe.lang.IGenericObject {
		
		object haxe_IMap_cast<K_c, V_c>();
		
		object keys();
		
		object iterator();
		
		string toString();
		
	}
}


