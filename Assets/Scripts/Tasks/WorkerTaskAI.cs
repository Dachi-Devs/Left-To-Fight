using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerTaskAI : MonoBehaviour
{
    private enum State
    { 
        WaitingForTask,
        ExecutingTask,
    }


    private IWorker worker;
    private TaskSystem taskSystem;
    private State state;
    private float waitingTimer;

    public void Setup(IWorker worker, TaskSystem taskSystem)
    {
        this.worker = worker;
        this.taskSystem = taskSystem;
        state = State.WaitingForTask;
    }

    private void Update()
    {
        switch (state)
        {
            case State.WaitingForTask:
                waitingTimer -= Time.deltaTime;
                if (waitingTimer < 0)
                {
                    float waitingTimerMax = .2f;
                    waitingTimer = waitingTimerMax;
                    RequestNextTask();
                }
                break;
            case State.ExecutingTask:
                break;

        }
    }

    private void RequestNextTask()
    {
        TaskSystem.Task task = taskSystem.RequestNextTask();
        if (task == null)
        {
            state = State.WaitingForTask;
        }
        else
        {
            state = State.ExecutingTask;
            ExecuteTask(task);
        }
    }

    private void ExecuteTask(TaskSystem.Task task)
    {
        worker.MoveTo(task.targetPos, () =>
        {
            state = State.WaitingForTask;
        });

    }
}
