
#ifdef BLOODSTONE_EXPORTS
#define BLOODSTONE_API __declspec(dllexport)
#else
#define BLOODSTONE_API __declspec(dllimport)
#endif

namespace Gen = System::Collections::Generic;
namespace Ds = Autodesk::DesignScript::Interfaces;

namespace Dynamo { namespace Bloodstone {

    class IGraphicsContext;
    class IShaderProgram;
    class IVertexBuffer;
    class GeometryData;
    class NodeGeometries;
    class BoundingBox;
    ref class Scene;

    typedef Gen::IEnumerable<Gen::KeyValuePair<System::String^, Ds::IRenderPackage^>> RenderPackages;

    public ref class VisualizerWnd
    {
    public:

        // Static class methods
        static System::IntPtr Create(System::IntPtr hwndParent, int width, int height);
        static void Destroy(void);
        static VisualizerWnd^ CurrentInstance(void);
        static LRESULT WndProc(HWND hWnd, UINT msg, WPARAM wParam, LPARAM lParam);

        // Public class methods.
        void ShowWindow(bool show);
        void RequestFrameUpdate(void);
        HWND GetWindowHandle(void);
        Scene^ GetScene(void);
        IGraphicsContext* GetGraphicsContext(void);

    private:

        // Private class instance methods.
        VisualizerWnd();
        void Initialize(HWND hWndParent, int width, int height);
        void Uninitialize(void);
        LRESULT ProcessMouseMessage(UINT msg, WPARAM wParam, LPARAM lParam);
        LRESULT ProcessMessage(HWND hWnd, UINT msg, WPARAM wParam, LPARAM lParam);

        // Static class data member.
        static VisualizerWnd^ mVisualizer = nullptr;

        // Class instance data members.
        HWND mhWndVisualizer;
        Scene^ mpScene;
        IGraphicsContext* mpGraphicsContext;
    };

    public ref class Scene
    {
    public:
        Scene(VisualizerWnd^ visualizer);
        void Initialize(int width, int height);
        void Destroy(void);
        void RenderScene(void);
        void UpdateNodeGeometries(RenderPackages^ nodeDetails);
        void RemoveNodeGeometries(Gen::IEnumerable<System::String^>^ nodes);

    private:
        void RenderGeometries(const std::vector<NodeGeometries *>& geometries);

    private:
        int mAlphaParamIndex;
        int mColorParamIndex;
        int mControlParamsIndex;
        IShaderProgram* mpShaderProgram;

        VisualizerWnd^ mVisualizer;
        std::map<std::wstring, NodeGeometries*>* mpNodeGeometries;
    };
} }