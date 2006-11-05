// Client.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "sharedMemoryDataTransfer.h"

long WINAPI AdminThread(long lParam);
TCHAR tcDataTransfer[] = L"SM_Server";
TCHAR tcDataTransferAdminThread[] = L"SM_Server_AdminThread";
  
int _tmain(int argc, _TCHAR* argv[])
{	
	
// Event test

	TCHAR tcQuestion[MIN_SIZE_OF_MESSAGE_DATA];			// this will not work with messages larger than MIN_SIZE_OF_MESSAGE_DATA
	TCHAR tcAnswer[MIN_SIZE_OF_MESSAGE_DATA];			// this will not work with messages larger than MIN_SIZE_OF_MESSAGE_DATA
	sharedMemoryDataTransfer smdtClient(L"SM_Client");		
	int i=0;
	while (1)
	{
		swprintf(tcQuestion,MIN_SIZE_OF_MESSAGE_DATA,L"Question#%i  , ",i++);
		//smdtClient.sendUsingEvent(L"This is a test message: 1,2,3");
		if (smdtClient.sendUsingEvent(tcQuestion,tcAnswer))
//		if (smdtClient.waitForEvent_Answer())
		{		
//			smdtClient.answer_getMessage(tcAnswer);
//			smdtClient.getAnswerToLastSentMessage(tcAnswer);
			wprintf(tcAnswer);
		}
		else
			wprintf(L"ERROR");
		Sleep(20);
}

//	smdtClient.sendUsingEvent(L"This is a test message: 1,2,3");
//	if (smdtClient.waitForAnswer())
//	{
//		
//		//Sleep(100);
//		smdtClient.getAnswerToLastSentMessage(tcAnswer);
//		wprintf(tcAnswer);
//	}
//	smdtClient.waitForAnswer();
//	smdtClient.getAnswerToLastSentMessage(tcAnswer);
//	wprintf(tcAnswer);
//	Sleep(2000);
//	getchar();
	//smdtClient
	return 0;

	HANDLE hAdminThread;
	hAdminThread = CreateThread(NULL,0,(LPTHREAD_START_ROUTINE)AdminThread,NULL,0,NULL);

	int inumberOfMessagesReceived = 0;
	sharedMemoryDataTransfer smdtServer(tcDataTransfer);		
/////	TCHAR tcMessageToProcess[MIN_SIZE_OF_MESSAGE_DATA];			// this will not work with messages larger than MIN_SIZE_OF_MESSAGE_DATA
	while(1)
	{
/////		smdtServer.receive(tcMessageToProcess,10,-1);
		
///////   smdtServer.answer_putMessage(L"Not_fileC.txt\x00");

		//smdtServer.sendUsingLastReceivedMessageSharedMemory(L"This is an Answer\n which is much larger than\n the original messsage   12345\x00");			// this cannot be larger than MIN_SIZE_OF_MESSAGE_DATA
//		smdtServer.sendUsingLastReceivedMessageSharedMemory(L"Not_fileC.txt\x00");			// this cannot be larger than the original request
//		smdtServer.sendUsingLastReceivedMessageSharedMemory(L"F:\\_Research\\SharedMemoryClientServer\\Server\\Server.cpp\x00");
	}

	return 0;
}


long WINAPI AdminThread(long lParam)
{
	/*
	sharedMemoryDataTransfer smdtServer(tcDataTransferAdminThread);		
	TCHAR tcAdminMessageToProcess[MIN_SIZE_OF_MESSAGE_DATA];			// this will not work with messages larger than MIN_SIZE_OF_MESSAGE_DATA
	while(1)
	{
		smdtServer.receive(tcAdminMessageToProcess,10,-1);
		MessageBox(NULL,tcAdminMessageToProcess,L"Messagebox", NULL);  
	}
		*/
	return 0;

}

