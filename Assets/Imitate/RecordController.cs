using System.Collections.Generic;

namespace Imitate
{
    public class RecordController
    {
        public static RecordController Instance => _instance ??= new RecordController();
        public List<Record> Recorder => _recorder;

        private static RecordController _instance = null;
        private List<Record> _recorder = new List<Record>();
    }
}
