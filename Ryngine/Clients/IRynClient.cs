using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ryngine.Clients
{
    public interface IRynClient
    {
        string GetState(string saveName);
        string SaveSnapshot(string currentSaveName, string savePrefix);

        string ApplyDelta(string saveName, string delta);
        void PostDelta(string saveName, string delta);
        string RequestUndo(string saveName);

        void LoadMultiverseFile(string filepath);
        void SaveMultiverseFile(string filepath);
    }
}
