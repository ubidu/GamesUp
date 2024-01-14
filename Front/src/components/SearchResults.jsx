import { useParams } from "react-router-dom";

const SearchResults = () => {
  const { query } = useParams();
  // Tutaj możesz użyć wartości 'query' do wyszukiwania gier i wyświetlenia wyników

  return (
    <div>
      <h1>Search Results for: {query}</h1>
      {/* Renderuj wyniki wyszukiwania */}
    </div>
  );
};

export default SearchResults;
