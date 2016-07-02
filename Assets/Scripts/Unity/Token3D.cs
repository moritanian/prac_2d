using UnityEngine;
using System.Collections;
using System;

/// 3dオブジェクト基底クラス.
/// MeshRendererが必要.
[RequireComponent (typeof(MeshRenderer))]
public class Token3D : MonoBehaviour
{
  /// インスタンスを生成してスクリプトを返す.
  public static Type CreateInstance<Type> (GameObject prefab, Vector3 p, float direction = 0.0f, float speed = 0.0f) where Type : Token
  {
    GameObject g = Instantiate (prefab, p, Quaternion.identity) as GameObject;
    Type obj = g.GetComponent<Type> ();
    if(obj.RigidBody)
    {
      // RigidBodyを登録している時だけ設定
      obj.SetVelocity (direction, speed);
    }
    return obj;
  }

  public static Type CreateInstance2<Type> (GameObject prefab, float x, float y, float direction = 0.0f, float speed = 0.0f) where Type : Token
  {
    Vector3 pos = new Vector3 (x, y, 0);
    return CreateInstance<Type> (prefab, pos, direction, speed);
  }

  public static Type CreateInstanceEasy<Type>(string prefab_name,float x = 0,float y = 0)where Type : Token
  {
    GameObject prefab = null;
    prefab = Util.GetPrefab(prefab, prefab_name);
    Vector3 pos = new Vector3(x, y ,0);
    return CreateInstance<Type> (prefab,pos,0,0);

  }
  /*
 public static Type CreateCanvasInstance<Type>(string prefab_name,float x = 0,float y = 0)where Type : Token
  {
    GameObject prefab = null;
    prefab = Util.GetPrefab(prefab, prefab_name);
    Vector3 pos = new Vector3(x, y ,0);
    GameObject g = Instantiate (prefab, pos, Quaternion.identity) as GameObject;
    g.transform.SetParent(MyCanvas.GetCanvas().transform,false);
    Type obj = g.GetComponent<Type> ();
    return obj;
  }
  */
  
  /// 生存フラグ.
  bool _exists = false;


  public bool Exists {
    get { return _exists; }
    set { _exists = value; }
  }

  /// アクセサ.
  /// レンダラー.
  MeshRenderer _renderer = null;

  public MeshRenderer Renderer {
    get { return _renderer ?? (_renderer = gameObject.GetComponent<MeshRenderer> ()); }
  }

  /// 描画フラグ.
  public bool Visible {
    get { return Renderer.enabled; }
    set { Renderer.enabled = value; }
  }

  /// ソーティングレイヤー名.
  public string SortingLayer {
    get { return Renderer.sortingLayerName; }
    set { Renderer.sortingLayerName = value; }
  }

  /// ソーティング・オーダー.
  public int SortingOrder {
    get { return Renderer.sortingOrder; }
    set { Renderer.sortingOrder = value; }
  }

  /// 座標(X).
  public float X {
    set {
      Vector3 pos = transform.position;
      pos.x = value;
      transform.position = pos;
    }
    get { return transform.position.x; }
  }

  /// 座標(Y).
  public float Y {
    set {
      Vector3 pos = transform.position;
      pos.y = value;
      transform.position = pos;
    }
    get { return transform.position.y; }
  }
 /// 座標(z).
  public float Z {
    set {
      Vector3 pos = transform.position;
      pos.z = value;
      transform.position = pos;
    }
    get { return transform.position.z; }
  }
  /// 座標をVector2で取得する
  public Vector2 GetPosition()
  {
    return transform.position;
  }

  /// 座標を足し込む.
  public void AddPosition (float dx, float dy)
  {
    X += dx;
    Y += dy;
  }

  /// 座標を設定する.
  public void SetPosition (Vector3 pos)
  {
    transform.position = pos;
  }
 

  /// スケール値(X).
  public float ScaleX {
    set {
      Vector3 scale = transform.localScale;
      scale.x = value;
      transform.localScale = scale;
    }
    get { return transform.localScale.x; }
  }

  /// スケール値(Y).
  public float ScaleY {
    set {
      Vector3 scale = transform.localScale;
      scale.y = value;
      transform.localScale = scale;
    }
    get { return transform.localScale.y; }
  }

 /// スケール値(Z).
  public float ScaleZ {
    set {
      Vector3 scale = transform.localScale;
      scale.z = value;
      transform.localScale = scale;
    }
    get { return transform.localScale.z; }
  }

  /// スケール値を設定.
  public void SetScale (float x, float y, float z)
  {
    Vector3 scale = transform.localScale;
    scale.Set (x, y, z);
    transform.localScale = scale;
  }

  /// スケール値(X/Y).
  public float Scale {
    get {
      Vector3 scale = transform.localScale;
      return (scale.x + scale.y + scale.z) / 2.0f;
    }
    set {
      Vector3 scale = transform.localScale;
      scale.x = value;
      scale.y = value;
      scale.z = value;
      transform.localScale = scale;
    }
  }

  /// スケール値を足し込む.
  public void AddScale (float d)
  {
    Vector3 scale = transform.localScale;
    scale.x += d;
    scale.y += d;
    scale.z += d;
    transform.localScale = scale;
  }

  /// スケール値をかける.
  public void MulScale (float d)
  {
    transform.localScale *= d;
  }

  /// 剛体.
  Rigidbody _rigidbody3D = null;

  public Rigidbody RigidBody {
    get { return _rigidbody3D ?? (_rigidbody3D = gameObject.GetComponent<Rigidbody> ()); }
  }

  /// 移動量を設定(X/Y).
  public void SetVelocity (Vector3 vel)
  {
    RigidBody.velocity = vel;
  }

  /// 移動量をかける.
  public void MulVelocity (float d)
  {
    RigidBody.velocity *= d;
  }

  /// 移動量(X).
  public float VX {
    get { return RigidBody.velocity.x; }
    set {
      Vector2 v = RigidBody.velocity;
      v.x = value;
      RigidBody.velocity = v;
    }
  }

  /// 移動量(Y).
  public float VY {
    get { return RigidBody.velocity.y; }
    set {
      Vector2 v = RigidBody.velocity;
      v.y = value;
      RigidBody.velocity = v;
    }
  }

  /// 移動量(Z).
  public float VZ {
    get { return RigidBody.velocity.z; }
    set {
      Vector3 v = RigidBody.velocity;
      v.z = value;
      RigidBody.velocity = v;
    }
  }
 

  /// 方向.
  public float Direction {
    get {
      Vector3 v = RigidBody.velocity;
      return Mathf.Atan2 (v.y, v.x) * Mathf.Rad2Deg;
    }
  }

  /// 速度.
  public float Speed {
    get {
      Vector3 v = RigidBody.velocity;
      return Mathf.Sqrt (v.x * v.x + v.y * v.y + v.z*v.z);
    }
  }
/*
  /// 重力.
  public float GravityScale {
    get { return RigidBody.gravityScale; }
    set { RigidBody.gravityScale = value; }
  }
*/
  /// 回転角度.
  public Vector3 Angle {
    set { transform.eulerAngles = value; }
    get { return transform.eulerAngles; }
  }

 // 回転角速度
 public Vector3 AngularVelocity {
    set { RigidBody.angularVelocity = value; }
    get { return RigidBody.angularVelocity; }
 } 

 public void InitPhisicalParameter(){
    Vector3 ZeroVec = new Vector3(0,0,0); 
    AngularVelocity = ZeroVec;
    SetVelocity(ZeroVec);
    //Angle = ZeroVec;
    //SetPosition(ZeroVec);
 }
  /// 消滅（メモリから削除）.
  public void DestroyObj ()
  {
    Destroy (gameObject);
  }

  /// アクティブにする.
  public virtual void Revive ()
  {
    gameObject.SetActive (true);
    Exists = true;
    Visible = true;
  }

  /// 消滅する（オーバーライド可能）
  /// ただし base.Vanish()を呼ばないと消滅しなくなることに注意
  public virtual void Vanish ()
  {
    VanishCannotOverride();
  }
  /// 消滅する（オーバーライド禁止）
  public void VanishCannotOverride ()
  {
    gameObject.SetActive (false);
    Exists = false;
  }

}
