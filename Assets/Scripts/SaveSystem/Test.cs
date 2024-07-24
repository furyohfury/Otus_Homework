using System.Diagnostics;
using System.Threading.Tasks;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.Architecture.SaveLoad
{
    public class Test : MonoBehaviour
    {
        // private int[] ar = new int[1000000];
        private double _summ;
        public int casFrom = 0;
        public int casTo = 10;
        public int parFrom = 0;
        public int parTo = 10;
        //[Button]
        //public void FillArray()
        //{
        //    for (int i = 0; i < ar.Length; i++)
        //    {
        //        ar[i] = i;
        //    }
        //}
        [Button]
        public void Casual()
        {
            var watch = new Stopwatch();
            watch.Start();
            _summ = 0;
            for (var i = casFrom; i < casTo; i++)
            {
                _summ += Mathf.Sqrt(i);
            }
            watch.Stop();
            UnityEngine.Debug.Log($"Time = {watch.Elapsed.TotalSeconds}, sum = {_summ.ToString("F2")}");
        }

        [Button]
        public void Par()
        {
            var watch = new Stopwatch();
            watch.Start();
            _summ = 0;
            Parallel.For(parFrom, parTo, Summ);
            watch.Stop();
            UnityEngine.Debug.Log($"Time = {watch.Elapsed.TotalSeconds}, sum = {_summ.ToString("F2")}");
        }

        private void Summ(int arg1, ParallelLoopState state)
        {
            _summ += Mathf.Sqrt(arg1);
        }
    }
}