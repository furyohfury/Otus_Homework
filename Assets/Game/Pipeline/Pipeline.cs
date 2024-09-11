using System;
using System.Collections.Generic;

namespace EventBus
{
	public abstract class Pipeline
	{
		public event Action OnFinished;

		private readonly List<EventTask> _tasks = new();

		private int _taskIndex = -1;

		public void AddTask(EventTask eventTask)
		{
			_tasks.Add(eventTask);
		}

		public void ClearAll()
		{
			_tasks.Clear();
			Reset();
		}

		public void Reset()
		{
			_taskIndex = -1;
		}

		public void RunNextTask()
		{
			_taskIndex++;

			if (_taskIndex >= _tasks.Count)
			{
				OnFinished?.Invoke();
				return;
			}

			_tasks[_taskIndex].Run(OnTaskFinished);
		}

		private void OnTaskFinished()
		{
			RunNextTask();
		}
	}
}