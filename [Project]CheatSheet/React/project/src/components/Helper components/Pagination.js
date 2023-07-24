

export const Pagination=({ currentPage, totalPages, onPageChange })=> {
  const pageNumbers = [];

  for (let i = 1; i <= totalPages; i++) {
    pageNumbers.push(i);
  }

  return (
    <div className="flex justify-center mt-8">
      {pageNumbers.map((pageNumber) => (
        <button
          key={pageNumber}
          onClick={() => onPageChange(pageNumber)}
          className={`${
            pageNumber === currentPage ? "bg-blue-500 text-white" : "bg-white text-gray-800"
          } font-bold py-2 px-4 mx-2 border border-gray-400 rounded-lg hover:bg-blue-500 hover:text-white`}
        >
          {pageNumber}
        </button>
      ))}
    </div>
  );
}
