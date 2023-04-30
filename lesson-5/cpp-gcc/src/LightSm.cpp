// Autogenerated with StateSmith 0.9.3-alpha.
// Algorithm: Balanced1. See https://github.com/StateSmith/StateSmith/wiki/Algorithms

// user IRenderConfigC.CFileTop: whatever you want to put in here.
#include <iostream> // user include. required for printf.
#include "LightSm.h"
// user IRenderConfigC.CFileIncludes: whatever you want to put in here.
#include <stdbool.h> // required for `consume_event` flag
#include <string.h> // for memset

// This function is used when StateSmith doesn't know what the active leaf state is at
// compile time due to sub states or when multiple states need to be exited.
static void exit_up_to_state_handler(LightSm* sm, LightSm_Func desired_state_exit_handler);

static void ROOT_enter(LightSm* sm);

static void ROOT_exit(LightSm* sm);

static void OFF_enter(LightSm* sm);

static void OFF_exit(LightSm* sm);

static void OFF_increase(LightSm* sm);

static void ON_GROUP_enter(LightSm* sm);

static void ON_GROUP_exit(LightSm* sm);

static void ON_GROUP_off(LightSm* sm);

static void ON_HOT_enter(LightSm* sm);

static void ON_HOT_exit(LightSm* sm);

static void ON_HOT_dim(LightSm* sm);

static void ON1_enter(LightSm* sm);

static void ON1_exit(LightSm* sm);

static void ON1_dim(LightSm* sm);

static void ON1_increase(LightSm* sm);

static void ON2_enter(LightSm* sm);

static void ON2_exit(LightSm* sm);

static void ON2_dim(LightSm* sm);

static void ON2_increase(LightSm* sm);


// State machine constructor. Must be called before start or dispatch event functions. Not thread safe.
void LightSm_ctor(LightSm* sm)
{
    memset(sm, 0, sizeof(*sm));
}

// Starts the state machine. Must be called before dispatching events. Not thread safe.
void LightSm_start(LightSm* sm)
{
    ROOT_enter(sm);
    // ROOT behavior
    // uml: TransitionTo(ROOT.InitialState)
    {
        // Step 1: Exit states until we reach `ROOT` state (Least Common Ancestor for transition). Already at LCA, no exiting required.
        
        // Step 2: Transition action: ``.
        
        // Step 3: Enter/move towards transition target `ROOT.InitialState`.
        // ROOT.InitialState is a pseudo state and cannot have an `enter` trigger.
        
        // ROOT.InitialState behavior
        // uml: TransitionTo(OFF)
        {
            // Step 1: Exit states until we reach `ROOT` state (Least Common Ancestor for transition). Already at LCA, no exiting required.
            
            // Step 2: Transition action: ``.
            
            // Step 3: Enter/move towards transition target `OFF`.
            OFF_enter(sm);
            
            // Step 4: complete transition. Ends event dispatch. No other behaviors are checked.
            sm->state_id = LightSm_StateId_OFF;
            // No ancestor handles event. Can skip nulling `ancestor_event_handler`.
            return;
        } // end of behavior for ROOT.InitialState
    } // end of behavior for ROOT
}

// Dispatches an event to the state machine. Not thread safe.
void LightSm_dispatch_event(LightSm* sm, LightSm_EventId event_id)
{
    LightSm_Func behavior_func = sm->current_event_handlers[event_id];
    
    while (behavior_func != NULL)
    {
        sm->ancestor_event_handler = NULL;
        behavior_func(sm);
        behavior_func = sm->ancestor_event_handler;
    }
}

// This function is used when StateSmith doesn't know what the active leaf state is at
// compile time due to sub states or when multiple states need to be exited.
static void exit_up_to_state_handler(LightSm* sm, LightSm_Func desired_state_exit_handler)
{
    while (sm->current_state_exit_handler != desired_state_exit_handler)
    {
        sm->current_state_exit_handler(sm);
    }
}


////////////////////////////////////////////////////////////////////////////////
// event handlers for state ROOT
////////////////////////////////////////////////////////////////////////////////

static void ROOT_enter(LightSm* sm)
{
    // setup trigger/event handlers
    sm->current_state_exit_handler = ROOT_exit;
}

static void ROOT_exit(LightSm* sm)
{
    // State machine root is a special case. It cannot be exited. Mark as unused.
    (void)sm;
}


////////////////////////////////////////////////////////////////////////////////
// event handlers for state OFF
////////////////////////////////////////////////////////////////////////////////

static void OFF_enter(LightSm* sm)
{
    // setup trigger/event handlers
    sm->current_state_exit_handler = OFF_exit;
    sm->current_event_handlers[LightSm_EventId_INCREASE] = OFF_increase;
    
    // OFF behavior
    // uml: enter / { std::cout << "OFF\n"; }
    {
        // Step 1: execute action `std::cout << "OFF\n";`
        std::cout << "OFF\n";
    } // end of behavior for OFF
}

static void OFF_exit(LightSm* sm)
{
    // adjust function pointers for this state's exit
    sm->current_state_exit_handler = ROOT_exit;
    sm->current_event_handlers[LightSm_EventId_INCREASE] = NULL;  // no ancestor listens to this event
}

static void OFF_increase(LightSm* sm)
{
    // No ancestor state handles `increase` event.
    
    // OFF behavior
    // uml: INCREASE TransitionTo(ON1)
    {
        // Step 1: Exit states until we reach `ROOT` state (Least Common Ancestor for transition).
        OFF_exit(sm);
        
        // Step 2: Transition action: ``.
        
        // Step 3: Enter/move towards transition target `ON1`.
        ON_GROUP_enter(sm);
        ON1_enter(sm);
        
        // Step 4: complete transition. Ends event dispatch. No other behaviors are checked.
        sm->state_id = LightSm_StateId_ON1;
        // No ancestor handles event. Can skip nulling `ancestor_event_handler`.
        return;
    } // end of behavior for OFF
}


////////////////////////////////////////////////////////////////////////////////
// event handlers for state ON_GROUP
////////////////////////////////////////////////////////////////////////////////

static void ON_GROUP_enter(LightSm* sm)
{
    // setup trigger/event handlers
    sm->current_state_exit_handler = ON_GROUP_exit;
    sm->current_event_handlers[LightSm_EventId_OFF] = ON_GROUP_off;
}

static void ON_GROUP_exit(LightSm* sm)
{
    // adjust function pointers for this state's exit
    sm->current_state_exit_handler = ROOT_exit;
    sm->current_event_handlers[LightSm_EventId_OFF] = NULL;  // no ancestor listens to this event
}

static void ON_GROUP_off(LightSm* sm)
{
    // No ancestor state handles `off` event.
    
    // ON_GROUP behavior
    // uml: OFF TransitionTo(OFF)
    {
        // Step 1: Exit states until we reach `ROOT` state (Least Common Ancestor for transition).
        exit_up_to_state_handler(sm, ROOT_exit);
        
        // Step 2: Transition action: ``.
        
        // Step 3: Enter/move towards transition target `OFF`.
        OFF_enter(sm);
        
        // Step 4: complete transition. Ends event dispatch. No other behaviors are checked.
        sm->state_id = LightSm_StateId_OFF;
        // No ancestor handles event. Can skip nulling `ancestor_event_handler`.
        return;
    } // end of behavior for ON_GROUP
}


////////////////////////////////////////////////////////////////////////////////
// event handlers for state ON_HOT
////////////////////////////////////////////////////////////////////////////////

static void ON_HOT_enter(LightSm* sm)
{
    // setup trigger/event handlers
    sm->current_state_exit_handler = ON_HOT_exit;
    sm->current_event_handlers[LightSm_EventId_DIM] = ON_HOT_dim;
    
    // ON_HOT behavior
    // uml: enter / { light_red(); }
    {
        // Step 1: execute action `light_red();`
        std::cout << "RED\n";;
    } // end of behavior for ON_HOT
}

static void ON_HOT_exit(LightSm* sm)
{
    // adjust function pointers for this state's exit
    sm->current_state_exit_handler = ON_GROUP_exit;
    sm->current_event_handlers[LightSm_EventId_DIM] = NULL;  // no ancestor listens to this event
}

static void ON_HOT_dim(LightSm* sm)
{
    // No ancestor state handles `dim` event.
    
    // ON_HOT behavior
    // uml: DIM TransitionTo(ON2)
    {
        // Step 1: Exit states until we reach `ON_GROUP` state (Least Common Ancestor for transition).
        ON_HOT_exit(sm);
        
        // Step 2: Transition action: ``.
        
        // Step 3: Enter/move towards transition target `ON2`.
        ON2_enter(sm);
        
        // Step 4: complete transition. Ends event dispatch. No other behaviors are checked.
        sm->state_id = LightSm_StateId_ON2;
        // No ancestor handles event. Can skip nulling `ancestor_event_handler`.
        return;
    } // end of behavior for ON_HOT
}


////////////////////////////////////////////////////////////////////////////////
// event handlers for state ON1
////////////////////////////////////////////////////////////////////////////////

static void ON1_enter(LightSm* sm)
{
    // setup trigger/event handlers
    sm->current_state_exit_handler = ON1_exit;
    sm->current_event_handlers[LightSm_EventId_DIM] = ON1_dim;
    sm->current_event_handlers[LightSm_EventId_INCREASE] = ON1_increase;
    
    // ON1 behavior
    // uml: enter / { light_blue(); }
    {
        // Step 1: execute action `light_blue();`
        std::cout << "BLUE\n";;
    } // end of behavior for ON1
}

static void ON1_exit(LightSm* sm)
{
    // adjust function pointers for this state's exit
    sm->current_state_exit_handler = ON_GROUP_exit;
    sm->current_event_handlers[LightSm_EventId_DIM] = NULL;  // no ancestor listens to this event
    sm->current_event_handlers[LightSm_EventId_INCREASE] = NULL;  // no ancestor listens to this event
}

static void ON1_dim(LightSm* sm)
{
    // No ancestor state handles `dim` event.
    
    // ON1 behavior
    // uml: DIM TransitionTo(OFF)
    {
        // Step 1: Exit states until we reach `ROOT` state (Least Common Ancestor for transition).
        exit_up_to_state_handler(sm, ROOT_exit);
        
        // Step 2: Transition action: ``.
        
        // Step 3: Enter/move towards transition target `OFF`.
        OFF_enter(sm);
        
        // Step 4: complete transition. Ends event dispatch. No other behaviors are checked.
        sm->state_id = LightSm_StateId_OFF;
        // No ancestor handles event. Can skip nulling `ancestor_event_handler`.
        return;
    } // end of behavior for ON1
}

static void ON1_increase(LightSm* sm)
{
    // No ancestor state handles `increase` event.
    
    // ON1 behavior
    // uml: INCREASE TransitionTo(ON2)
    {
        // Step 1: Exit states until we reach `ON_GROUP` state (Least Common Ancestor for transition).
        ON1_exit(sm);
        
        // Step 2: Transition action: ``.
        
        // Step 3: Enter/move towards transition target `ON2`.
        ON2_enter(sm);
        
        // Step 4: complete transition. Ends event dispatch. No other behaviors are checked.
        sm->state_id = LightSm_StateId_ON2;
        // No ancestor handles event. Can skip nulling `ancestor_event_handler`.
        return;
    } // end of behavior for ON1
}


////////////////////////////////////////////////////////////////////////////////
// event handlers for state ON2
////////////////////////////////////////////////////////////////////////////////

static void ON2_enter(LightSm* sm)
{
    // setup trigger/event handlers
    sm->current_state_exit_handler = ON2_exit;
    sm->current_event_handlers[LightSm_EventId_DIM] = ON2_dim;
    sm->current_event_handlers[LightSm_EventId_INCREASE] = ON2_increase;
    
    // ON2 behavior
    // uml: enter / { light_yellow(); }
    {
        // Step 1: execute action `light_yellow();`
        std::cout << "YELL-OH\n";;
    } // end of behavior for ON2
    
    // ON2 behavior
    // uml: enter / { count = 0; }
    {
        // Step 1: execute action `count = 0;`
        sm->vars.count = 0;
    } // end of behavior for ON2
}

static void ON2_exit(LightSm* sm)
{
    // adjust function pointers for this state's exit
    sm->current_state_exit_handler = ON_GROUP_exit;
    sm->current_event_handlers[LightSm_EventId_DIM] = NULL;  // no ancestor listens to this event
    sm->current_event_handlers[LightSm_EventId_INCREASE] = NULL;  // no ancestor listens to this event
}

static void ON2_dim(LightSm* sm)
{
    // No ancestor state handles `dim` event.
    
    // ON2 behavior
    // uml: DIM TransitionTo(ON1)
    {
        // Step 1: Exit states until we reach `ON_GROUP` state (Least Common Ancestor for transition).
        ON2_exit(sm);
        
        // Step 2: Transition action: ``.
        
        // Step 3: Enter/move towards transition target `ON1`.
        ON1_enter(sm);
        
        // Step 4: complete transition. Ends event dispatch. No other behaviors are checked.
        sm->state_id = LightSm_StateId_ON1;
        // No ancestor handles event. Can skip nulling `ancestor_event_handler`.
        return;
    } // end of behavior for ON2
}

static void ON2_increase(LightSm* sm)
{
    // No ancestor state handles `increase` event.
    
    // ON2 behavior
    // uml: 1. INCREASE / { count++; }
    {
        // Step 1: execute action `count++;`
        sm->vars.count++;
        
        // Step 2: determine if ancestor gets to handle event next.
        // No ancestor handles event. Can skip nulling `ancestor_event_handler`.
    } // end of behavior for ON2
    
    // ON2 behavior
    // uml: 2. INCREASE [count >= 3] TransitionTo(ON_HOT)
    if (sm->vars.count >= 3)
    {
        // Step 1: Exit states until we reach `ON_GROUP` state (Least Common Ancestor for transition).
        ON2_exit(sm);
        
        // Step 2: Transition action: ``.
        
        // Step 3: Enter/move towards transition target `ON_HOT`.
        ON_HOT_enter(sm);
        
        // Step 4: complete transition. Ends event dispatch. No other behaviors are checked.
        sm->state_id = LightSm_StateId_ON_HOT;
        // No ancestor handles event. Can skip nulling `ancestor_event_handler`.
        return;
    } // end of behavior for ON2
}

// Thread safe.
char const * LightSm_state_id_to_string(LightSm_StateId id)
{
    switch (id)
    {
        case LightSm_StateId_ROOT: return "ROOT";
        case LightSm_StateId_OFF: return "OFF";
        case LightSm_StateId_ON_GROUP: return "ON_GROUP";
        case LightSm_StateId_ON_HOT: return "ON_HOT";
        case LightSm_StateId_ON1: return "ON1";
        case LightSm_StateId_ON2: return "ON2";
        default: return "?";
    }
}

// Thread safe.
char const * LightSm_event_id_to_string(LightSm_EventId id)
{
    switch (id)
    {
        case LightSm_EventId_DIM: return "DIM";
        case LightSm_EventId_INCREASE: return "INCREASE";
        case LightSm_EventId_OFF: return "OFF";
        default: return "?";
    }
}
