﻿// ---------------------------------------------------------------------
// This file is auto-generated by behaviac designer, so please don't modify it by yourself!
// ---------------------------------------------------------------------

using System.Collections.Generic;

namespace behaviac
{
	partial class AgentMeta
	{

		static partial void registerMeta()
		{
			// ---------------------------------------------------------------------
			// properties
			// ---------------------------------------------------------------------

			AgentMeta meta;

			// behaviac.Agent
			meta = new AgentMeta();
			_agentMetas[2436498804] = meta;

			AgentMeta.Register<behaviac.EBTStatus>("behaviac.EBTStatus");
			AgentMeta.Register<FSM_Ctrl>("FSM_Ctrl");

		}

		static partial void unRegisterMeta()
		{
			AgentMeta.UnRegister<behaviac.EBTStatus>("behaviac.EBTStatus");
			AgentMeta.UnRegister<FSM_Ctrl>("FSM_Ctrl");
		}
	}
}