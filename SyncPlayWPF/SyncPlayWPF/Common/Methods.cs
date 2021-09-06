using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace SyncPlayWPF.Common {
    public class Methods {
        public static bool IsUserVisible(FrameworkElement element, FrameworkElement container) {
            if (!element.IsVisible)
                return false;

            Rect bounds = element.TransformToAncestor(container).TransformBounds(new Rect(0.0, 0.0, element.ActualWidth, element.ActualHeight));
            Rect rect = new Rect(0.0, 0.0, container.ActualWidth, container.ActualHeight);
            return rect.Contains(bounds.TopLeft) || rect.Contains(bounds.BottomRight);
        }

        public static bool isElementClickable<T>(UIElement container, UIElement element, out bool isPartiallyClickable) {
            isPartiallyClickable = false;
            Rect pos = GetAbsolutePlacement((FrameworkElement)container, (FrameworkElement)element);
            bool isTopLeftClickable = GetIsPointClickable<T>(container, element, new Point(pos.TopLeft.X + 1, pos.TopLeft.Y + 1));
            bool isBottomLeftClickable = GetIsPointClickable<T>(container, element, new Point(pos.BottomLeft.X + 1, pos.BottomLeft.Y - 1));
            bool isTopRightClickable = GetIsPointClickable<T>(container, element, new Point(pos.TopRight.X - 1, pos.TopRight.Y + 1));
            bool isBottomRightClickable = GetIsPointClickable<T>(container, element, new Point(pos.BottomRight.X - 1, pos.BottomRight.Y - 1));

            if (isTopLeftClickable || isBottomLeftClickable || isTopRightClickable || isBottomRightClickable) {
                isPartiallyClickable = true;
            }

            return isTopLeftClickable && isBottomLeftClickable && isTopRightClickable && isBottomRightClickable; // return if element is fully clickable
        }

        public static bool GetIsPointClickable<T>(UIElement container, UIElement element, Point p) {
            DependencyObject hitTestResult = HitTest<T>(p, container);
            if (null != hitTestResult) {
                return isElementChildOfElement(element, hitTestResult);
            }
            return false;
        }

        public static DependencyObject HitTest<T>(Point p, UIElement container) {
            PointHitTestParameters parameter = new PointHitTestParameters(p);
            DependencyObject hitTestResult = null;

            HitTestResultCallback resultCallback = (result) =>
            {
                UIElement elemCandidateResult = result.VisualHit as UIElement;
                // result can be collapsed! Even though documentation indicates otherwise
                if (null != elemCandidateResult && elemCandidateResult.Visibility == Visibility.Visible) {
                    hitTestResult = result.VisualHit;
                    return HitTestResultBehavior.Stop;
                }

                return HitTestResultBehavior.Continue;
            };

            HitTestFilterCallback filterCallBack = (potentialHitTestTarget) =>
            {
                if (potentialHitTestTarget is T) {
                    hitTestResult = potentialHitTestTarget;
                    return HitTestFilterBehavior.Stop;
                }

                return HitTestFilterBehavior.Continue;
            };

            VisualTreeHelper.HitTest(container, filterCallBack, resultCallback, parameter);
            return hitTestResult;
        }

        public static bool isElementChildOfElement(DependencyObject child, DependencyObject parent) {
            if (child.GetHashCode() == parent.GetHashCode())
                return true;
            IEnumerable<DependencyObject> elemList = FindVisualChildren<DependencyObject>((DependencyObject)parent);
            foreach (DependencyObject obj in elemList) {
                if (obj.GetHashCode() == child.GetHashCode())
                    return true;
            }
            return false;
        }

        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject {
            if (depObj != null) {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++) {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T) {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child)) {
                        yield return childOfChild;
                    }
                }
            }
        }

        public static Rect GetAbsolutePlacement(FrameworkElement container, FrameworkElement element, bool relativeToScreen = false) {
            var absolutePos = element.PointToScreen(new System.Windows.Point(0, 0));
            if (relativeToScreen) {
                return new Rect(absolutePos.X, absolutePos.Y, element.ActualWidth, element.ActualHeight);
            }
            var posMW = container.PointToScreen(new System.Windows.Point(0, 0));
            absolutePos = new System.Windows.Point(absolutePos.X - posMW.X, absolutePos.Y - posMW.Y);
            return new Rect(absolutePos.X, absolutePos.Y, element.ActualWidth, element.ActualHeight);
        }

        public static string ConvertByteSize(int bytecount) {
            // Bigger than a giga byte
            if (bytecount > 1073741824f) return (bytecount / (1024f * 1024f * 1024f)).ToString("0.0") + " GB";

            // Bigger than a megabyte
            if (bytecount > 1048576f) return (bytecount / (1024f * 1024f)).ToString("0.0") + " MB";

            return (bytecount / 1024).ToString("0.0") + " KB";
        }

    }
}
