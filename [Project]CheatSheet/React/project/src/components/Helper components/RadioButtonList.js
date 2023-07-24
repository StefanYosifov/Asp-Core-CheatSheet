
export const RadioButtonList = ({ radioButton, setRadioButton,selectedButton }) => {
    return (
        <div className="flex flex-col my-4 text-lg font-sans">
            <h1 className="font-medium p-1">Sort by: </h1>
            {radioButton.map((option, index) => (
                <label key={index} className="inline-flex items-center my-2">
                    <input
                        type="radio"
                        value={option}
                        checked={selectedButton == option}
                        onChange={(event) => setRadioButton(event.target.value)}
                        className="form-radio h-5 w-5 text-blue-600 focus:ring-blue-500 border-gray-300"
                    />
                    <span className="ml-2">{option}</span>
                </label>
            ))}
        </div>
    )
}