export default {
  content: [
      "./index.html",
      "./src/**/*.{vue,js,ts,jsx,tsx}",
  ],
  theme: {
      extend: {
          colors: {
              bgColor: '#f4f4f4',
              bgColorDark: '#333333',
              textColor: '#1c1c1c',
              textColorDark: '#FFFFFF',
              textSecondary: '#626262',
              textSecondaryDark: '#d4d4d4',
              successColor: '#48BB78',
              failedColor: '#F56565',
          }
      },
  },
  plugins: [],
}