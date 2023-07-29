/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["./src/**/*.{html,js}"],
  theme: {
    extend: {
      colors: {
        pinkUI: { 0: '#754FFE' },
        bgGray: { 0: '#bdc3c7' },
        bgWhiteUI:{0:'#FFFFFF'},
        bgBlackUI:{0:'#252525'}
      },
      width: {
        '1/7': '14.2857143%',
        '2/7': '28.5714286%',
        '3/7': '42.8571429%',
        '4/7': '57.1428571%',
        '5/7': '71.4285714%',
        '6/7': '85.7142857%',
      },
      spacing: {
        '128': '32rem',
      }
    },
  },
  plugins: [],
}