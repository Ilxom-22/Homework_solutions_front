export default {
  content: [
    "*",
    "./src/**/*.{vue,js,ts,jsx,tsx}",
  ],
  theme: {
    screens: {
      sm: '545px',
      md: '745px',
      lg: '950px',
      xl: '1440px',
    },

    extend: {
      colors: {
        textPrimary: '#222222',
        textSecondary: '#818181',
        logoSelected: '#000000',
        logoSecondary: '#717171',
        logoPrimary: '#ff385c',
        logoAccent: '#ddddd',
        defaultBackground: '#ffffff',
        borderSecondary: '#cccccc'
      }
    },
  },
  plugins: [],
}