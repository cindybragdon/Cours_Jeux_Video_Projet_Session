using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
 
// Classe de base représentant un état pour le NPC (personnage non joueur)
public class SmallEnnemyState {
 
    // Différents états possibles pour le NPC
    public enum STATE {
        IDLE,      // En attente
        PATROL,    // En patrouille
        RUNAWAY,    // En fuite vers une zone sécurisée

        STARE
    };
 
    // Événements d'état pour gérer les transitions
    public enum EVENT {
        ENTER,     // Entrée dans un état
        UPDATE,    // Mise à jour pendant un état
        EXIT       // Sortie d'un état
    };
 
    public STATE name;                   // Nom de l'état actuel
    protected EVENT stage;               // Événement actuel de l'état
    protected GameObject npc;            // Référence au NPC
    protected Animator anim;             // Contrôleur d'animation du NPC
    protected Transform player;          // Référence au joueur
    protected SmallEnnemyState nextState;           // Prochain état du NPC
    protected NavMeshAgent agent;        // Agent de navigation pour les déplacements
 
    // Variables de distance et d'angle pour détecter le joueur
    float visDist = 6.0f;               // Distance de vision
    float visAngle = 60.0f;              // Angle de vision

    float fleeDist = 3.0f;               // Distance de fuite
 
    // Constructeur pour initialiser les paramètres de l'état
    public SmallEnnemyState(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _player) {
        npc = _npc;
        agent = _agent;
        anim = _anim;
        player = _player;
        stage = EVENT.ENTER;
    }
 
    // Méthodes virtuelles pour gérer l'entrée, la mise à jour, et la sortie des états
    public virtual void Enter() { stage = EVENT.UPDATE; }
    public virtual void Update() { stage = EVENT.UPDATE; }
    public virtual void Exit() { stage = EVENT.EXIT; }
 
    // Processus pour gérer le cycle de vie de chaque état
    public SmallEnnemyState Process() {
        if (stage == EVENT.ENTER) Enter();
        if (stage == EVENT.UPDATE) Update();
        if (stage == EVENT.EXIT) {
            Exit();
            return nextState; // Retourne le prochain état après la sortie
        }
        return this;
    }
 
    // Méthode pour vérifier si le NPC peut voir le joueur
    public bool CanSeePlayer() {
        Vector3 direction = player.position - npc.transform.position;
        float angle = Vector3.Angle(direction, npc.transform.forward);
        if (direction.magnitude < visDist && angle < visAngle) {
            return true;
        }
        return false;
    }
 

     // Méthode pour vérifier si le NPC peut voir le joueur
    public bool fleePlayer() {
        float distance = Vector3.Distance(npc.transform.position, player.position);
        if (distance < fleeDist) {
            return true;
        }
        return false;
    }

}
 
// État "Idle" : NPC reste en attente
public class Idle : SmallEnnemyState {
    public Idle(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _player)
        : base(_npc, _agent, _anim, _player) {
        name = STATE.IDLE;
    }
 
    public override void Enter() {
        anim.SetTrigger("isIdle"); // Déclenche l'animation d'attente
        base.Enter();
    }
 
    public override void Update() {
        if (CanSeePlayer()) {
            Debug.Log("I see player");
            nextState = new Stare(npc, agent, anim, player);
            stage = EVENT.EXIT;
        } else if (Random.Range(0, 100) < 10) {
            nextState = new Patrol(npc, agent, anim, player);
            stage = EVENT.EXIT;
        }
    }
 
    public override void Exit() {
        anim.ResetTrigger("isIdle"); // Réinitialise l'animation d'attente
        base.Exit();
    }
}
 
// État "Patrol" : NPC patrouille autour des points de contrôle
public class Patrol : SmallEnnemyState {
    int currentIndex = -1;
 
    public Patrol(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _player)
        : base(_npc, _agent, _anim, _player) {
        name = STATE.PATROL;
        agent.speed = 2.0f;
        agent.isStopped = false;
    }
 
    public override void Enter() {
        // Trouve le point de patrouille le plus proche pour commencer
        float lastDistance = Mathf.Infinity;
        
        for (int i = 0; i < SmallEnnemyGameEnvironment.Singleton.Checkpoints.Count; ++i) {
            GameObject thisWP = SmallEnnemyGameEnvironment.Singleton.Checkpoints[i];
            float distance = Vector3.Distance(npc.transform.position, thisWP.transform.position);
            if (distance < lastDistance) {
                currentIndex = i - 1;
                lastDistance = distance;
            }
        }
        anim.SetTrigger("isWalking");
        base.Enter();
    }
 
    public override void Update() {


         
        if (CanSeePlayer()) {
            Debug.Log("JE regarde le joueur");
            nextState = new Stare(npc, agent, anim, player);
            stage = EVENT.EXIT;
        } else if (agent.remainingDistance < 1) {
            currentIndex = Random.Range(0,SmallEnnemyGameEnvironment.Singleton.Checkpoints.Count);
            agent.SetDestination(SmallEnnemyGameEnvironment.Singleton.Checkpoints[currentIndex].transform.position);
        }

    }
 
    public override void Exit() {
        anim.ResetTrigger("isWalking");
        base.Exit();
    }
}
 


// État "RunAway" : NPC s'enfuit vers un lieu sûr
public class RunAway : SmallEnnemyState {
    GameObject[] safeLocations;
    
    public RunAway(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _player)
        : base(_npc, _agent, _anim, _player) {
        name = STATE.RUNAWAY;
        safeLocations = GameObject.FindGameObjectsWithTag("Safe"); 
        agent.speed = 3.0f;
    }

    public override void Enter() {
        anim.SetTrigger("isWalking");
        agent.isStopped = false;
        agent.SetDestination(safeLocations[Random.Range(0,safeLocations.Length)].transform.position);

        base.Enter();
    }
 
    public override void Update() {
        if (agent.remainingDistance < 1.0f) {
            if(!fleePlayer()){
                nextState = new Idle(npc, agent, anim, player);
                stage = EVENT.EXIT;
            } else {
                agent.SetDestination(safeLocations[Random.Range(0,safeLocations.Length)].transform.position);
            }
        }
    }
 
    public override void Exit() {
        anim.ResetTrigger("isWalking");
        base.Exit();
    }
}


// État "RunAway" : NPC s'enfuit vers un lieu sûr
public class Stare : SmallEnnemyState {

 
    public Stare(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _player)
        : base(_npc, _agent, _anim, _player) {
        name = STATE.STARE;
       
    }
 
    public override void Enter() {
        anim.SetTrigger("isIdle");
        agent.isStopped = true;
        base.Enter();
    }
 
    public override void Update() {
 
        if (fleePlayer()) {
            nextState = new RunAway(npc, agent, anim, player);
            stage = EVENT.EXIT;
        } else {
            npc.gameObject.transform.LookAt(player);
        }
    }
 
    public override void Exit() {
        anim.ResetTrigger("isWalking");
        base.Exit();
    }
}