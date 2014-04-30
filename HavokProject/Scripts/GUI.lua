-- new script file
#include <Vision/Runtime/EnginePlugins/VisionEnginePlugin/GUI/vGUI.hpp>

VSmartPtr<VGUIMainContext> spGUIContext;
VDialogPtr spMainDlg;

void InitGUI()
{
  spGUIContext = new VGUIMainContext(NULL);
  spGUIContext->SetActivate(true);

  // Load some default resource (like the image for our cursor)
  VGUIManager::GlobalManager().LoadResourceFile("Dialogs\\MenuSystem.xml");

  // Load the Main Menu
  spMainDlg = spGUIContext->ShowDialog("Dialogs\\MainMenu.xml");
  VASSERT(spMainDlg);
}


VISION_INIT
{
  // ...

  InitGUI();
  ModalDialogExample();

  return true;
}
void DeinitGUI()
{
  spMainDlg = NULL; // destroy the MainDlg Object
  spGUIContext->SetActivate(false); // Don't forget to deinit the GUI context
  spGUIContext = NULL; // destroy the GUI context
}
VISION_DEINIT
{
  DeinitGUI();

  // ...
}
VISION_SAMPLEAPP_RUN
{
  return spApp->Run() && spMainDlg->GetDialogResult()!=VGUIManager::ID_CANCEL;
}
void ModalDialogExample()
{
  IVisApp_cl* spModalApp = NULL; // passing a NULL pointer is equivalent to passing the current Application
  int iDialogResult = spGUIContext->ShowDialogModal(NULL, "Dialogs\\MessageBox_AbortRequest.xml", hkvVec2(0,0), spModalApp);
  if (iDialogResult==VGUIManager::ID_YES) // Abort the game
    spApp->Quit();
}
