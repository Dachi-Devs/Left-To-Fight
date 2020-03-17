using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class TaskHandler : MonoBehaviour
{
    private TaskSystem taskSystem;

    void Start()
    {
        taskSystem = new TaskSystem();

        Worker worker = Worker.Create(new Vector3(500, 500));
        WorkerTaskAI workerTaskAI = worker.gameObject.AddComponent<WorkerTaskAI>();
        workerTaskAI.Setup(worker, taskSystem);

        //FunctionTimer.Create(() =>
        //{
        //    TaskSystem.Task task = new TaskSystem.Task { targetPos = new Vector3(550, 550) };
        //    taskSystem.AddTask(task);
        //}, 5f);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TaskSystem.Task task = new TaskSystem.Task { targetPos = UtilsClass.GetMouseWorldPosition() };
            taskSystem.AddTask(task);
        }
    }
}
