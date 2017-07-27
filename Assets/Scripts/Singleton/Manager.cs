public class Manager : Singleton<Manager> {
	protected Manager () {} // guarantee this will be always a singleton only - can't use the constructor!
 
	//public string myGlobalVar = "whatever";
	public bool firstStart = true;
	public bool m_IsInsertCoin = false;
	public bool m_IsSpin = false;
	public bool m_IsSpinL = false;
	public bool m_IsSpinC = false;
	public bool m_IsSpinR = false;
	public bool m_IsWin = false;
	public bool m_TurnIsEnd = false;
	public int m_Score = 0;
	public int m_Balance = 100;
	public float m_SpeedSlotL, m_SpeedSlotC, m_SpeedSlotR;
	public bool m_changeSpeedSwich = false;
	public float m_GlobalTimer = 0f;
	public UnityEngine.Vector3 m_SlotLCenterPosition, m_SlotCCenterPosition, m_SlotRCenterPosition;
	public string m_LeftCellName, m_CenterCellName, m_RightCellName;
}
