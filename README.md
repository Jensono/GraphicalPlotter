# GraphicalPlotter

GraphicalPlotter is a WPF-based Function Plotter that offers a plethora of features for graphing and visualizing functions.

## Features

- **Function Support**: Currently supports sinus, cosinus, tangent, and polynomial functions up to the 10th order.
  
- **Function customization**: 
  - Assign names to functions.
  - Modify function display colors.
  - Adjust the display width of functions.

- **Canvas customization**:
  - Customize the visible range of the x and y-Axis.
  - Alter the color, visibility, and stroke width of the Axis.
  - Grid customization: Adjust interval between gridlines, color visibility, and width of the gridlines.

- **Autoscaler**: Automatically scales the canvas to fit and display newly added functions.

- **Function animations**: A wheel traverses the entire length of the function, rotating based on the curvature derived from the second derivative of the function.

- **Save and Import functions**: Easily save your work and import function groups through an intuitive menu.

- **Interactive zoom**: Users can zoom into specific portions of the graph by drawing a smaller window directly on the canvas.

- **Automatic status saving**: The application automatically saves all parameters (including canvas settings and function details) before closing.

## Preview

### Displaying normal functions
![Displaying normal functions](https://github.com/Jensono/GraphicalPlotter/assets/121871613/b97ea63c-ac25-4b9c-aa5b-2a82cbb753d3)

### Displaying more complex functions
![Displaying more complex functions](https://github.com/Jensono/GraphicalPlotter/assets/121871613/736c3314-7c3c-4406-98da-8f165bf312cd)

### Wheel animation for function curvature
![Wheel Animation for function curvature](https://github.com/Jensono/GraphicalPlotter/assets/121871613/660d509a-41bc-4190-898d-f846ea045a42)

### Zoom functionality inside the canvas
![GraphicalPlotter_N3Fu7YINei](https://github.com/Jensono/GraphicalPlotter/assets/121871613/b7e876c2-33f7-4b9d-b43b-5521adb184a6)


## How to input functions

For **polynomials**, use the following format:
`( a3 * x^3 + a2 * x^2 + a1 * x + a0 )`

For **trigonometric functions**, the following formats are supported:
- `( a * sin(b * x) + c)`
- `(  a * cos(b * x) + c)`
- `( a * tan(b * x) + c)`

Different function types, such as sin, cos, tan, and polynomial, can be subtracted and added to each other. However, they cannot be divided or multiplied. 

**Example of a valid function:** 
`x^5 + cos(x)`

**Example of an invalid function:** 
`x^2 * 5 * sin(x)`

When hovering over the the function insert field there is also a tooltip explaining this concept



