// Server.cpp : Defines the entry point for the console application.
//
#include "stdafx.h"

#include "sharedMemoryDataTransfer.h"

TCHAR tcDataTransferAdminThread[] = L"SM_Server_AdminThread";

int _tmain(int argc, _TCHAR* argv[])
{	

	// example of continuously listening to messages

	int inumberOfMessagesReceived = 0;
	sharedMemoryDataTransfer smdtClient(L"SM_Client");		
//	sharedMemoryDataTransfer smdtServer(L"SM_Server");		
	TCHAR tcMessageToProcess[MIN_SIZE_OF_MESSAGE_DATA];
	while(1)
	{		
		if (smdtClient.UnReadMessages())		
		{
			int iAnswerPosition =  smdtClient.getNextMessageToProcess(tcMessageToProcess);						
			if(smdtClient.smdSharedMemoryDataPointer->ptsmWithMessageToProcess[iAnswerPosition].bWithAnswer)	
			{	
				/*
				TCHAR debugMsd[1024];
				swprintf(debugMsd,1024,L"<server>pos = %i , tcMessageToProcess = %s</server>",iAnswerPosition,tcMessageToProcess);
				OutputDebugStringW(debugMsd);
				*/
				TCHAR tcAnswer[MIN_SIZE_OF_MESSAGE_DATA];
				//swprintf(tcAnswer,MAX_SIZE_OF_ANSWER_DATA,L"Custom answer for %s",tcMessageToProcess);
				//swprintf(tcAnswer,MAX_SIZE_OF_ANSWER_DATA,L"%s",tcMessageToProcess);
				//swprintf(tcAnswer,MAX_SIZE_OF_ANSWER_DATA,L"test.bat");//,tcMessageToProcess);
				
				// sending back as answer the original message
				swprintf(tcAnswer,MIN_SIZE_OF_MESSAGE_DATA,L"%s",tcMessageToProcess);//,tcMessageToProcess);
				/*
				swprintf(debugMsd,1024,L"<server>pos = %i , tcAnswer = %s</server>",iAnswerPosition,tcAnswer);
				OutputDebugStringW(debugMsd);
				*/
				smdtClient.sendAnswerUsingEvent(tcAnswer,iAnswerPosition); 

			}
			wprintf(L"[%i] : %s\n",++inumberOfMessagesReceived,tcMessageToProcess);	   						
		}
		else
		{	
			if (!smdtClient.waitForEvent_NewMessage())						
				wprintf(L"*");					
		}

	}



	// example to have the client and server talk to each other in a loop
	/*
	int inumberOfMessagesReceived = 0;
	sharedMemoryDataTransfer smdtClient(L"SM_Client");		
	sharedMemoryDataTransfer smdtServer(L"SM_Server");		
	TCHAR tcMessageToProcess[MAX_SIZE_OF_SHARED_MEMORY_NAME];
	while(1)
	{
		smdtClient.send(L"Client send");
		smdtServer.receive(tcMessageToProcess,10,-1);
		wprintf(L"\nClient receive: %s,",tcMessageToProcess);
		//Sleep(1000);
	}
*/
//	{
//
//		while(smdtClient.getNextMessageToProcess(tcMessageToProcess))
//		{
//			wprintf(L"[%1i] : %s\n",++inumberOfMessagesReceived,tcMessageToProcess);	   
//		}
//		Sleep(2000);
//	}
	return 0;
}

