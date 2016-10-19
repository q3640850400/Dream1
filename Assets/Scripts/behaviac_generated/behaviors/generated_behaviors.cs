// ---------------------------------------------------------------------
// This file is auto-generated by behaviac designer, so please don't modify it by yourself!
// Export file: ../../Assets/Scripts/behaviac_generated/behaviors/generated_behaviors.cs
// ---------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace behaviac
{
	// Source file: FSM_Ctrl

	[behaviac.GeneratedTypeMetaInfo()]
	class State_bt_FSM_Ctrl_node1 : behaviac.State
	{
		public State_bt_FSM_Ctrl_node1()
		{
			this.m_bIsEndState = false;
		}
		protected override EBTStatus update_impl(behaviac.Agent pAgent, behaviac.EBTStatus childStatus)
		{
			return behaviac.EBTStatus.BT_RUNNING;
		}
	}

	[behaviac.GeneratedTypeMetaInfo()]
	class Precondition_bt_FSM_Ctrl_attach6 : behaviac.Precondition
	{
		public Precondition_bt_FSM_Ctrl_attach6()
		{
			this.Phase = Precondition.EPhase.E_ENTER;
			this.IsAnd = true;
		}
		protected override EBTStatus update_impl(behaviac.Agent pAgent, behaviac.EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int opr2 = 0;
			((FSM_Ctrl)pAgent).Status = opr2;
			return result;
		}
	}

	[behaviac.GeneratedTypeMetaInfo()]
	class Precondition_bt_FSM_Ctrl_attach7 : behaviac.Precondition
	{
		public Precondition_bt_FSM_Ctrl_attach7()
		{
			this.Phase = Precondition.EPhase.E_ENTER;
			this.IsAnd = true;
		}
		protected override EBTStatus update_impl(behaviac.Agent pAgent, behaviac.EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int opr2 = 0;
			((FSM_Ctrl)pAgent).MouseStatus = opr2;
			return result;
		}
	}

	[behaviac.GeneratedTypeMetaInfo()]
	class Transition_bt_FSM_Ctrl_attach4 : behaviac.Transition
	{
		public Transition_bt_FSM_Ctrl_attach4()
		{
			this.TargetStateId = 2;
		}
		protected override EBTStatus update_impl(behaviac.Agent pAgent, behaviac.EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int opl = ((FSM_Ctrl)pAgent).Status;
			int opr2 = 1;
			bool op = (opl == opr2);
			if (!op)
				result = EBTStatus.BT_FAILURE;
			return result;
		}
	}

	[behaviac.GeneratedTypeMetaInfo()]
	class Transition_bt_FSM_Ctrl_attach5 : behaviac.Transition
	{
		public Transition_bt_FSM_Ctrl_attach5()
		{
			this.TargetStateId = 3;
		}
		protected override EBTStatus update_impl(behaviac.Agent pAgent, behaviac.EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int opl = ((FSM_Ctrl)pAgent).Status;
			int opr2 = 2;
			bool op = (opl == opr2);
			if (!op)
				result = EBTStatus.BT_FAILURE;
			return result;
		}
	}

	[behaviac.GeneratedTypeMetaInfo()]
	class State_bt_FSM_Ctrl_node2 : behaviac.State
	{
		public State_bt_FSM_Ctrl_node2()
		{
			this.m_bIsEndState = false;
			method_params = null;
		}
		protected override EBTStatus update_impl(behaviac.Agent pAgent, behaviac.EBTStatus childStatus)
		{
			AgentMetaVisitor.ExecuteMethod(pAgent, "Selecting", method_params);
			return behaviac.EBTStatus.BT_RUNNING;
		}
		object[] method_params;
	}

	[behaviac.GeneratedTypeMetaInfo()]
	class State_bt_FSM_Ctrl_node3 : behaviac.State
	{
		public State_bt_FSM_Ctrl_node3()
		{
			this.m_bIsEndState = false;
			method_params = null;
		}
		protected override EBTStatus update_impl(behaviac.Agent pAgent, behaviac.EBTStatus childStatus)
		{
			AgentMetaVisitor.ExecuteMethod(pAgent, "ReadyConstruct", method_params);
			return behaviac.EBTStatus.BT_RUNNING;
		}
		object[] method_params;
	}

	[behaviac.GeneratedTypeMetaInfo()]
	class Precondition_bt_FSM_Ctrl_attach12 : behaviac.Precondition
	{
		public Precondition_bt_FSM_Ctrl_attach12()
		{
			opl_params = null;
			this.Phase = Precondition.EPhase.E_ENTER;
			this.IsAnd = true;
		}
		protected override EBTStatus update_impl(behaviac.Agent pAgent, behaviac.EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			AgentMetaVisitor.ExecuteMethod(pAgent, "Enter_ReadyConstruct", opl_params);
			return result;
		}
		object[] opl_params;
	}

	[behaviac.GeneratedTypeMetaInfo()]
	class Transition_bt_FSM_Ctrl_attach8 : behaviac.Transition
	{
		public Transition_bt_FSM_Ctrl_attach8()
		{
			this.TargetStateId = 9;
		}
		protected override EBTStatus update_impl(behaviac.Agent pAgent, behaviac.EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			int opl = ((FSM_Ctrl)pAgent).MouseStatus;
			int opr2 = 1;
			bool op = (opl == opr2);
			if (!op)
				result = EBTStatus.BT_FAILURE;
			return result;
		}
	}

	[behaviac.GeneratedTypeMetaInfo()]
	class State_bt_FSM_Ctrl_node9 : behaviac.State
	{
		public State_bt_FSM_Ctrl_node9()
		{
			this.m_bIsEndState = false;
			method_params = null;
		}
		protected override EBTStatus update_impl(behaviac.Agent pAgent, behaviac.EBTStatus childStatus)
		{
			AgentMetaVisitor.ExecuteMethod(pAgent, "Constructing", method_params);
			return behaviac.EBTStatus.BT_RUNNING;
		}
		object[] method_params;
	}

	[behaviac.GeneratedTypeMetaInfo()]
	class Precondition_bt_FSM_Ctrl_attach11 : behaviac.Precondition
	{
		public Precondition_bt_FSM_Ctrl_attach11()
		{
			this.Phase = Precondition.EPhase.E_ENTER;
			this.IsAnd = true;
		}
		protected override EBTStatus update_impl(behaviac.Agent pAgent, behaviac.EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			bool opr2 = false;
			((FSM_Ctrl)pAgent).isConAva = opr2;
			return result;
		}
	}

	[behaviac.GeneratedTypeMetaInfo()]
	class Transition_bt_FSM_Ctrl_attach10 : behaviac.Transition
	{
		public Transition_bt_FSM_Ctrl_attach10()
		{
			this.TargetStateId = 1;
		}
		protected override EBTStatus update_impl(behaviac.Agent pAgent, behaviac.EBTStatus childStatus)
		{
			EBTStatus result = EBTStatus.BT_SUCCESS;
			bool opl = ((FSM_Ctrl)pAgent).isConAva;
			bool opr2 = true;
			bool op = (opl == opr2);
			if (!op)
				result = EBTStatus.BT_FAILURE;
			return result;
		}
	}

	public static class bt_FSM_Ctrl
	{
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("FSM_Ctrl");
			bt.IsFSM = true;
#if !BEHAVIAC_RELEASE
			bt.SetAgentType("FSM_Ctrl");
#endif
			// attachments
			// children
			{
				FSM fsm = new FSM();
				fsm.SetClassNameString("FSM");
				fsm.SetId(-1);
				fsm.InitialId = 1;
#if !BEHAVIAC_RELEASE
				fsm.SetAgentType("FSM_Ctrl");
#endif
				{
					State_bt_FSM_Ctrl_node1 node1 = new State_bt_FSM_Ctrl_node1();
					node1.SetClassNameString("State");
					node1.SetId(1);
#if !BEHAVIAC_RELEASE
					node1.SetAgentType("FSM_Ctrl");
#endif
					// attachments
					{
						Precondition_bt_FSM_Ctrl_attach6 attach6 = new Precondition_bt_FSM_Ctrl_attach6();
						attach6.SetClassNameString("Precondition");
						attach6.SetId(6);
#if !BEHAVIAC_RELEASE
						attach6.SetAgentType("FSM_Ctrl");
#endif
						node1.Attach(attach6, true, false, false);
					}
					{
						Precondition_bt_FSM_Ctrl_attach7 attach7 = new Precondition_bt_FSM_Ctrl_attach7();
						attach7.SetClassNameString("Precondition");
						attach7.SetId(7);
#if !BEHAVIAC_RELEASE
						attach7.SetAgentType("FSM_Ctrl");
#endif
						node1.Attach(attach7, true, false, false);
					}
					{
						Transition_bt_FSM_Ctrl_attach4 attach4 = new Transition_bt_FSM_Ctrl_attach4();
						attach4.SetClassNameString("Transition");
						attach4.SetId(4);
#if !BEHAVIAC_RELEASE
						attach4.SetAgentType("FSM_Ctrl");
#endif
						node1.Attach(attach4, false, false, true);
					}
					{
						Transition_bt_FSM_Ctrl_attach5 attach5 = new Transition_bt_FSM_Ctrl_attach5();
						attach5.SetClassNameString("Transition");
						attach5.SetId(5);
#if !BEHAVIAC_RELEASE
						attach5.SetAgentType("FSM_Ctrl");
#endif
						node1.Attach(attach5, false, false, true);
					}
					fsm.AddChild(node1);
					fsm.SetHasEvents(fsm.HasEvents() | node1.HasEvents());
				}
				{
					State_bt_FSM_Ctrl_node2 node2 = new State_bt_FSM_Ctrl_node2();
					node2.SetClassNameString("State");
					node2.SetId(2);
#if !BEHAVIAC_RELEASE
					node2.SetAgentType("FSM_Ctrl");
#endif
					fsm.AddChild(node2);
					fsm.SetHasEvents(fsm.HasEvents() | node2.HasEvents());
				}
				{
					State_bt_FSM_Ctrl_node3 node3 = new State_bt_FSM_Ctrl_node3();
					node3.SetClassNameString("State");
					node3.SetId(3);
#if !BEHAVIAC_RELEASE
					node3.SetAgentType("FSM_Ctrl");
#endif
					// attachments
					{
						Precondition_bt_FSM_Ctrl_attach12 attach12 = new Precondition_bt_FSM_Ctrl_attach12();
						attach12.SetClassNameString("Precondition");
						attach12.SetId(12);
#if !BEHAVIAC_RELEASE
						attach12.SetAgentType("FSM_Ctrl");
#endif
						node3.Attach(attach12, true, false, false);
					}
					{
						Transition_bt_FSM_Ctrl_attach8 attach8 = new Transition_bt_FSM_Ctrl_attach8();
						attach8.SetClassNameString("Transition");
						attach8.SetId(8);
#if !BEHAVIAC_RELEASE
						attach8.SetAgentType("FSM_Ctrl");
#endif
						node3.Attach(attach8, false, false, true);
					}
					fsm.AddChild(node3);
					fsm.SetHasEvents(fsm.HasEvents() | node3.HasEvents());
				}
				{
					State_bt_FSM_Ctrl_node9 node9 = new State_bt_FSM_Ctrl_node9();
					node9.SetClassNameString("State");
					node9.SetId(9);
#if !BEHAVIAC_RELEASE
					node9.SetAgentType("FSM_Ctrl");
#endif
					// attachments
					{
						Precondition_bt_FSM_Ctrl_attach11 attach11 = new Precondition_bt_FSM_Ctrl_attach11();
						attach11.SetClassNameString("Precondition");
						attach11.SetId(11);
#if !BEHAVIAC_RELEASE
						attach11.SetAgentType("FSM_Ctrl");
#endif
						node9.Attach(attach11, true, false, false);
					}
					{
						Transition_bt_FSM_Ctrl_attach10 attach10 = new Transition_bt_FSM_Ctrl_attach10();
						attach10.SetClassNameString("Transition");
						attach10.SetId(10);
#if !BEHAVIAC_RELEASE
						attach10.SetAgentType("FSM_Ctrl");
#endif
						node9.Attach(attach10, false, false, true);
					}
					fsm.AddChild(node9);
					fsm.SetHasEvents(fsm.HasEvents() | node9.HasEvents());
				}
				bt.AddChild(fsm);
			}
			return true;
		}
	}

}
