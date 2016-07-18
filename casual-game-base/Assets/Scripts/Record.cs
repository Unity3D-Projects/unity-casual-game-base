using System;
using System.Collections.Generic;

namespace CasualBase
{
	class RecordHelper {
		System.Random random = new System.Random ();

		public Record getRandomRecord(){
			double dbl = random.NextDouble();
			Record record = new Record();
			record.Timestamp = CasualSerializeManager.GetDateTime();
			record.Value = dbl;
			return record;
		}
	}

	[System.Serializable]
	class Record : System.Object
	{
		public DateTime Timestamp { get; set; }
		public double Value { get; set; }

		public override string ToString(){
			return "Timestamp[ " +Timestamp+ " ], Value[ "+ Value +" ]";
		}
	}
	
	[System.Serializable]
	class RecordList : System.Object
	{
		private Record[] records;
		public Record highScore { get; set; }

		[System.NonSerialized]
		private List<Record> recordList;

		public RecordList(){
			recordList = new List<Record> ();
		}

		public Record findHighScore(){
			if (records == null || records.Length == 0) {
				return null;
			}

			double max = records [0].Value;
			Record hs = null;
			foreach(Record record in records){
				if(record.Value > max){
					max = record.Value;
					hs = record;
				}
			}
			if(hs != null){
				this.highScore = hs;
			}
			return hs;
		}
		public void add(Record record){
			if (recordList == null) {
				recordList = new List<Record>(records);
			}
			if (record != null) {
				recordList.Add (record);
				
				if(highScore == null || highScore != null && record.Value > highScore.Value) {
					highScore = record;
				}
			}
			records = recordList.ToArray ();
		}

		public override string ToString(){
			if(highScore == null){
				findHighScore ();
			}
			if(highScore == null){
				return "HighScore[], Records{ }";
			}

			string val = "HighScore [ " + highScore.ToString() + " ] , Records: {\n";
			foreach(Record record in records){
				val += "  { ";
				val += record.ToString();
				val += " }, \n";
			}
			val += "\n}";
			return val;
		}
	}

	
//	class RecordExample {
//		private void print(object message){
//			UnityEngine.Debug.Log (message);
//		}
//		public void start () {
//			string filePath = "test-records.casual";
//			
//			CasualSerializeManager casualSerializeManager = CasualSerializeManager.getInstance ();
//			RecordHelper rh = new RecordHelper ();
//			
//			RecordList recordList = casualSerializeManager.loadFile<RecordList>(filePath);
//			//Preloading from file if any.
//			if (null == recordList) {
//				recordList = new RecordList ();
//			}
//			print ("Preloaded recordList..");
//			print (recordList);
//			
//			//Adding 3 new files.
//			recordList.add (rh.getRandomRecord());
//			recordList.add (rh.getRandomRecord());
//			recordList.add (rh.getRandomRecord());
//			
//			print ("Altered recordList..");
//			
//			print (recordList);
//			
//			casualSerializeManager.saveToFile(filePath, recordList);
//			
//			RecordList oRecords = casualSerializeManager.loadFile<RecordList>(filePath);
//			
//			print ("Reloading recordList..");
//			print (oRecords);
//		}
//	}
}

