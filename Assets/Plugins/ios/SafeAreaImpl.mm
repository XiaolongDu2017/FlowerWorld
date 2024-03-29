
#include <CoreGraphics/CoreGraphics.h>
#include "UnityAppController.h"
#include "UI/UnityView.h"

CGRect CustomComputeSafeArea(UIView* view)
{
	CGSize screenSize = view.bounds.size;
	CGRect screenRect = CGRectMake(0, 0, screenSize.width, screenSize.height);
	
	UIEdgeInsets insets = UIEdgeInsetsMake(0, 0, 0, 0);
	if ([view respondsToSelector: @selector(safeAreaInsets)])
		insets = [view safeAreaInsets];
	
	screenRect.origin.x += insets.left;
	screenRect.origin.y += insets.bottom; // Unity uses bottom left as the origin
	screenRect.size.width -= insets.left + insets.right;
	screenRect.size.height -= insets.top + insets.bottom;
	
	float scale = view.contentScaleFactor;
	screenRect.origin.x *= scale;
	screenRect.origin.y *= scale;
	screenRect.size.width *= scale;
	screenRect.size.height *= scale;
	return screenRect;
}

bool HasSafeAreaInsets (UIView* view){
    if ([view respondsToSelector: @selector(safeAreaInsets)]){
        UIEdgeInsets insets = [view safeAreaInsets];
        if (insets.left != 0 || insets.right != 0 || insets.top != 0 || insets.bottom != 0) {
            return true;
        }
    }
    
    return false;
}

extern "C" void GetSafeAreaImpl(float* x, float* y, float* w, float* h)
{
	UIView* view = GetAppController().unityView;
	CGRect area = CustomComputeSafeArea(view);
	*x = area.origin.x;
	*y = area.origin.y;
	*w = area.size.width;
	*h = area.size.height;
}

extern "C" bool IsSafeAreaInsets (){
     UIView* view = GetAppController().unityView;
    
    return HasSafeAreaInsets (view);
}

