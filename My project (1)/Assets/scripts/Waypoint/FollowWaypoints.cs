using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWaypoints : MonoBehaviour
{
    // variaveis de controle do tanque
    Transform goal;
    float speed = 5.0f;
    float accuracy = 2.0f;
    float rotSpeed = 10.0f;
    // variaveis de controle dos waypoints
    public WaypointManager waypointManager;
    GameObject[] waypoints;
    GameObject currentNode;
    int currentWaypoint = 0;
    Graph graph;

    void Start()
    {
        // inicializa as variáveis
        waypoints = waypointManager.waypoints;
        graph = waypointManager.graph;
        currentNode = waypoints[0];

        // Invoke(nameof(GoToRuin), 2.0f);
    }
    // métodos para ir para waypoints específicos
    public void Fogueira()
    {
        graph.AStar(currentNode, waypoints[0]);
        currentWaypoint = 0;
    }

    public void Casa()
    {
        graph.AStar(currentNode, waypoints[1]);
        currentWaypoint = 0;
    }
    
    public void Casinha()
    {
        graph.AStar(currentNode, waypoints[2]);
        currentWaypoint = 0;
    }

    public void reserva_de_pau()
    {
        graph.AStar(currentNode, waypoints[3]);
        currentWaypoint = 0;
    }

    public void Reserva_de_informações()
    {
        graph.AStar(currentNode, waypoints[4]);
        currentWaypoint = 0;
    }

    public void Mesinha_do_Walter_White()
    {
        graph.AStar(currentNode, waypoints[5]);
        currentWaypoint = 0;
    }

    public void Cantinho_dos_bambu()
    {
        graph.AStar(currentNode, waypoints[6]);
        currentWaypoint = 0;
    }

    public void Reserva_de_preda()
    {
        graph.AStar(currentNode, waypoints[7]);
        currentWaypoint = 0;
    }

    public void Arbusto_de_cereja()
    {
        graph.AStar(currentNode, waypoints[8]);
        currentWaypoint = 0;
    }

    public void Bebedouro()
    {
        graph.AStar(currentNode, waypoints[9]);
        currentWaypoint = 0;
    }

    public void Informações()
    {
        graph.AStar(currentNode, waypoints[10]);
        currentWaypoint = 0;
    }

    void Update()
    {
        // não temos caminho ou já chegamos ao destino
        if(graph.GetPath().Count == 0 || currentWaypoint == graph.GetPath().Count) return;
        // se chegamos ao destino, vamos para o próximo waypoint
        if (Vector3.Distance(graph.GetPath()[currentWaypoint].GetId().transform.position, transform.position) < accuracy)
        {
            currentNode = graph.GetPath()[currentWaypoint].GetId();
            currentWaypoint++;
        }
        // se não chegamos ao destino, vamos para o waypoint e olhamos para ele
        if(currentWaypoint < graph.GetPath().Count)
        {
            goal = graph.GetPath()[currentWaypoint].GetId().transform;
            Vector3 lookAtGoal = new Vector3(goal.position.x, transform.position.y, goal.position.z);
            Vector3 direction = lookAtGoal - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotSpeed);
            transform.Translate(0, 0, speed * Time.deltaTime);
        }
    }
}
