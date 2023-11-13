
function useFetch() {
    const [user, setUser] = useState(null);
    const [isAuthenticated, setIsAuthenticated] = useState(false);
  
    useEffect(() => {
      async function fetchData() {
        try {
          const response = await Authenticate();
          setUser(response);
          if (response) {
            setIsAuthenticated(true);
            await setUser(response);
          }
        } catch (error) {
          console.error("Error during login:", error);
        }
      }
      fetchData();
  
      return () => console.log("asdasd");
    }, []);
  
    return [user, isAuthenticated, setIsAuthenticated];
}
