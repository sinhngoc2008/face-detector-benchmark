��
��
8
Const
output"dtype"
valuetensor"
dtypetype

NoOp
C
Placeholder
output"dtype"
dtypetype"
shapeshape:
@
ReadVariableOp
resource
value"dtype"
dtypetype�
�
StatefulPartitionedCall
args2Tin
output2Tout"
Tin
list(type)("
Tout
list(type)("	
ffunc"
configstring "
config_protostring "
executor_typestring �
q
VarHandleOp
resource"
	containerstring "
shared_namestring "
dtypetype"
shapeshape�"serve*1.15.02unknown8��
~
conv2d/kernelVarHandleOp*
shape: *
shared_nameconv2d/kernel*
dtype0*
_output_shapes
: 
w
!conv2d/kernel/Read/ReadVariableOpReadVariableOpconv2d/kernel*
dtype0*&
_output_shapes
: 
n
conv2d/biasVarHandleOp*
shape: *
shared_nameconv2d/bias*
dtype0*
_output_shapes
: 
g
conv2d/bias/Read/ReadVariableOpReadVariableOpconv2d/bias*
dtype0*
_output_shapes
: 

NoOpNoOp
�	
ConstConst"/device:CPU:0*�
value�B� B�
�
layer-0
layer_with_weights-0
layer-1
trainable_variables
	variables
regularization_losses
	keras_api

signatures
R
trainable_variables
		variables

regularization_losses
	keras_api
~

kernel
bias
_callable_losses
trainable_variables
	variables
regularization_losses
	keras_api

0
1

0
1
 
�

layers
metrics
trainable_variables
	variables
layer_regularization_losses
regularization_losses
non_trainable_variables
 
 
 
 
�

layers
metrics
trainable_variables
		variables
layer_regularization_losses

regularization_losses
non_trainable_variables
YW
VARIABLE_VALUEconv2d/kernel6layer_with_weights-0/kernel/.ATTRIBUTES/VARIABLE_VALUE
US
VARIABLE_VALUEconv2d/bias4layer_with_weights-0/bias/.ATTRIBUTES/VARIABLE_VALUE
 

0
1

0
1
 
�

layers
metrics
trainable_variables
	variables
layer_regularization_losses
regularization_losses
non_trainable_variables

0
 
 
 
 
 
 
 
 
 
 
 *
dtype0*
_output_shapes
: 
�
serving_default_conv2d_inputPlaceholder*$
shape:���������  *
dtype0*/
_output_shapes
:���������  
�
StatefulPartitionedCallStatefulPartitionedCallserving_default_conv2d_inputconv2d/kernelconv2d/bias**
_gradient_op_typePartitionedCall-173**
f%R#
!__inference_signature_wrapper_126*
Tout
2*-
config_proto

CPU

GPU2*0J 8*
Tin
2*/
_output_shapes
:��������� 
O
saver_filenamePlaceholder*
shape: *
dtype0*
_output_shapes
: 
�
StatefulPartitionedCall_1StatefulPartitionedCallsaver_filename!conv2d/kernel/Read/ReadVariableOpconv2d/bias/Read/ReadVariableOpConst**
_gradient_op_typePartitionedCall-197*%
f R
__inference__traced_save_196*
Tout
2*-
config_proto

CPU

GPU2*0J 8*
Tin
2*
_output_shapes
: 
�
StatefulPartitionedCall_2StatefulPartitionedCallsaver_filenameconv2d/kernelconv2d/bias**
_gradient_op_typePartitionedCall-216*(
f#R!
__inference__traced_restore_215*
Tout
2*-
config_proto

CPU

GPU2*0J 8*
Tin
2*
_output_shapes
: ��
�
�
C__inference_sequential_layer_call_and_return_conditional_losses_111

inputs0
,conv2d_statefulpartitionedcall_conv2d_kernel.
*conv2d_statefulpartitionedcall_conv2d_bias
identity��conv2d/StatefulPartitionedCall�
conv2d/StatefulPartitionedCallStatefulPartitionedCallinputs,conv2d_statefulpartitionedcall_conv2d_kernel*conv2d_statefulpartitionedcall_conv2d_bias*)
_gradient_op_typePartitionedCall-57*G
fBR@
>__inference_conv2d_layer_call_and_return_conditional_losses_50*
Tout
2*-
config_proto

CPU

GPU2*0J 8*
Tin
2*/
_output_shapes
:��������� �
IdentityIdentity'conv2d/StatefulPartitionedCall:output:0^conv2d/StatefulPartitionedCall*
T0*/
_output_shapes
:��������� "
identityIdentity:output:0*6
_input_shapes%
#:���������  ::2@
conv2d/StatefulPartitionedCallconv2d/StatefulPartitionedCall: :& "
 
_user_specified_nameinputs: 
�
�
B__inference_sequential_layer_call_and_return_conditional_losses_73
conv2d_input0
,conv2d_statefulpartitionedcall_conv2d_kernel.
*conv2d_statefulpartitionedcall_conv2d_bias
identity��conv2d/StatefulPartitionedCall�
conv2d/StatefulPartitionedCallStatefulPartitionedCallconv2d_input,conv2d_statefulpartitionedcall_conv2d_kernel*conv2d_statefulpartitionedcall_conv2d_bias*)
_gradient_op_typePartitionedCall-57*G
fBR@
>__inference_conv2d_layer_call_and_return_conditional_losses_50*
Tout
2*-
config_proto

CPU

GPU2*0J 8*
Tin
2*/
_output_shapes
:��������� �
IdentityIdentity'conv2d/StatefulPartitionedCall:output:0^conv2d/StatefulPartitionedCall*
T0*/
_output_shapes
:��������� "
identityIdentity:output:0*6
_input_shapes%
#:���������  ::2@
conv2d/StatefulPartitionedCallconv2d/StatefulPartitionedCall: :, (
&
_user_specified_nameconv2d_input: 
�
�
(__inference_sequential_layer_call_fn_165

inputs)
%statefulpartitionedcall_conv2d_kernel'
#statefulpartitionedcall_conv2d_bias
identity��StatefulPartitionedCall�
StatefulPartitionedCallStatefulPartitionedCallinputs%statefulpartitionedcall_conv2d_kernel#statefulpartitionedcall_conv2d_bias**
_gradient_op_typePartitionedCall-112*L
fGRE
C__inference_sequential_layer_call_and_return_conditional_losses_111*
Tout
2*-
config_proto

CPU

GPU2*0J 8*
Tin
2*/
_output_shapes
:��������� �
IdentityIdentity StatefulPartitionedCall:output:0^StatefulPartitionedCall*
T0*/
_output_shapes
:��������� "
identityIdentity:output:0*6
_input_shapes%
#:���������  ::22
StatefulPartitionedCallStatefulPartitionedCall: :& "
 
_user_specified_nameinputs: 
�

�
C__inference_sequential_layer_call_and_return_conditional_losses_140

inputs.
*conv2d_conv2d_readvariableop_conv2d_kernel-
)conv2d_biasadd_readvariableop_conv2d_bias
identity��conv2d/BiasAdd/ReadVariableOp�conv2d/Conv2D/ReadVariableOp�
conv2d/Conv2D/ReadVariableOpReadVariableOp*conv2d_conv2d_readvariableop_conv2d_kernel*
dtype0*&
_output_shapes
: �
conv2d/Conv2DConv2Dinputs$conv2d/Conv2D/ReadVariableOp:value:0*
T0*
strides
*
paddingVALID*/
_output_shapes
:��������� �
conv2d/BiasAdd/ReadVariableOpReadVariableOp)conv2d_biasadd_readvariableop_conv2d_bias*
dtype0*
_output_shapes
: �
conv2d/BiasAddBiasAddconv2d/Conv2D:output:0%conv2d/BiasAdd/ReadVariableOp:value:0*
T0*/
_output_shapes
:��������� f
conv2d/ReluReluconv2d/BiasAdd:output:0*
T0*/
_output_shapes
:��������� �
IdentityIdentityconv2d/Relu:activations:0^conv2d/BiasAdd/ReadVariableOp^conv2d/Conv2D/ReadVariableOp*
T0*/
_output_shapes
:��������� "
identityIdentity:output:0*6
_input_shapes%
#:���������  ::2>
conv2d/BiasAdd/ReadVariableOpconv2d/BiasAdd/ReadVariableOp2<
conv2d/Conv2D/ReadVariableOpconv2d/Conv2D/ReadVariableOp: :& "
 
_user_specified_nameinputs: 
�
�
__inference__traced_restore_215
file_prefix"
assignvariableop_conv2d_kernel"
assignvariableop_1_conv2d_bias

identity_3��AssignVariableOp�AssignVariableOp_1�	RestoreV2�RestoreV2_1�
RestoreV2/tensor_namesConst"/device:CPU:0*�
valuexBvB6layer_with_weights-0/kernel/.ATTRIBUTES/VARIABLE_VALUEB4layer_with_weights-0/bias/.ATTRIBUTES/VARIABLE_VALUE*
dtype0*
_output_shapes
:t
RestoreV2/shape_and_slicesConst"/device:CPU:0*
valueBB B *
dtype0*
_output_shapes
:�
	RestoreV2	RestoreV2file_prefixRestoreV2/tensor_names:output:0#RestoreV2/shape_and_slices:output:0"/device:CPU:0*
dtypes
2*
_output_shapes

::L
IdentityIdentityRestoreV2:tensors:0*
T0*
_output_shapes
:z
AssignVariableOpAssignVariableOpassignvariableop_conv2d_kernelIdentity:output:0*
dtype0*
_output_shapes
 N

Identity_1IdentityRestoreV2:tensors:1*
T0*
_output_shapes
:~
AssignVariableOp_1AssignVariableOpassignvariableop_1_conv2d_biasIdentity_1:output:0*
dtype0*
_output_shapes
 �
RestoreV2_1/tensor_namesConst"/device:CPU:0*1
value(B&B_CHECKPOINTABLE_OBJECT_GRAPH*
dtype0*
_output_shapes
:t
RestoreV2_1/shape_and_slicesConst"/device:CPU:0*
valueB
B *
dtype0*
_output_shapes
:�
RestoreV2_1	RestoreV2file_prefix!RestoreV2_1/tensor_names:output:0%RestoreV2_1/shape_and_slices:output:0
^RestoreV2"/device:CPU:0*
dtypes
2*
_output_shapes
:1
NoOpNoOp"/device:CPU:0*
_output_shapes
 �

Identity_2Identityfile_prefix^AssignVariableOp^AssignVariableOp_1^NoOp"/device:CPU:0*
T0*
_output_shapes
: �

Identity_3IdentityIdentity_2:output:0^AssignVariableOp^AssignVariableOp_1
^RestoreV2^RestoreV2_1*
T0*
_output_shapes
: "!

identity_3Identity_3:output:0*
_input_shapes

: ::2
	RestoreV2	RestoreV22(
AssignVariableOp_1AssignVariableOp_12
RestoreV2_1RestoreV2_12$
AssignVariableOpAssignVariableOp: :+ '
%
_user_specified_namefile_prefix: 
�

�
C__inference_sequential_layer_call_and_return_conditional_losses_151

inputs.
*conv2d_conv2d_readvariableop_conv2d_kernel-
)conv2d_biasadd_readvariableop_conv2d_bias
identity��conv2d/BiasAdd/ReadVariableOp�conv2d/Conv2D/ReadVariableOp�
conv2d/Conv2D/ReadVariableOpReadVariableOp*conv2d_conv2d_readvariableop_conv2d_kernel*
dtype0*&
_output_shapes
: �
conv2d/Conv2DConv2Dinputs$conv2d/Conv2D/ReadVariableOp:value:0*
T0*
strides
*
paddingVALID*/
_output_shapes
:��������� �
conv2d/BiasAdd/ReadVariableOpReadVariableOp)conv2d_biasadd_readvariableop_conv2d_bias*
dtype0*
_output_shapes
: �
conv2d/BiasAddBiasAddconv2d/Conv2D:output:0%conv2d/BiasAdd/ReadVariableOp:value:0*
T0*/
_output_shapes
:��������� f
conv2d/ReluReluconv2d/BiasAdd:output:0*
T0*/
_output_shapes
:��������� �
IdentityIdentityconv2d/Relu:activations:0^conv2d/BiasAdd/ReadVariableOp^conv2d/Conv2D/ReadVariableOp*
T0*/
_output_shapes
:��������� "
identityIdentity:output:0*6
_input_shapes%
#:���������  ::2>
conv2d/BiasAdd/ReadVariableOpconv2d/BiasAdd/ReadVariableOp2<
conv2d/Conv2D/ReadVariableOpconv2d/Conv2D/ReadVariableOp: :& "
 
_user_specified_nameinputs: 
�

�
>__inference_conv2d_layer_call_and_return_conditional_losses_50

inputs'
#conv2d_readvariableop_conv2d_kernel&
"biasadd_readvariableop_conv2d_bias
identity��BiasAdd/ReadVariableOp�Conv2D/ReadVariableOp�
Conv2D/ReadVariableOpReadVariableOp#conv2d_readvariableop_conv2d_kernel*
dtype0*&
_output_shapes
: �
Conv2DConv2DinputsConv2D/ReadVariableOp:value:0*
T0*
strides
*
paddingVALID*A
_output_shapes/
-:+��������������������������� u
BiasAdd/ReadVariableOpReadVariableOp"biasadd_readvariableop_conv2d_bias*
dtype0*
_output_shapes
: �
BiasAddBiasAddConv2D:output:0BiasAdd/ReadVariableOp:value:0*
T0*A
_output_shapes/
-:+��������������������������� j
ReluReluBiasAdd:output:0*
T0*A
_output_shapes/
-:+��������������������������� �
IdentityIdentityRelu:activations:0^BiasAdd/ReadVariableOp^Conv2D/ReadVariableOp*
T0*A
_output_shapes/
-:+��������������������������� "
identityIdentity:output:0*H
_input_shapes7
5:+���������������������������::2.
Conv2D/ReadVariableOpConv2D/ReadVariableOp20
BiasAdd/ReadVariableOpBiasAdd/ReadVariableOp: :& "
 
_user_specified_nameinputs: 
�
�
#__inference_conv2d_layer_call_fn_62

inputs)
%statefulpartitionedcall_conv2d_kernel'
#statefulpartitionedcall_conv2d_bias
identity��StatefulPartitionedCall�
StatefulPartitionedCallStatefulPartitionedCallinputs%statefulpartitionedcall_conv2d_kernel#statefulpartitionedcall_conv2d_bias*)
_gradient_op_typePartitionedCall-57*G
fBR@
>__inference_conv2d_layer_call_and_return_conditional_losses_50*
Tout
2*-
config_proto

CPU

GPU2*0J 8*
Tin
2*A
_output_shapes/
-:+��������������������������� �
IdentityIdentity StatefulPartitionedCall:output:0^StatefulPartitionedCall*
T0*A
_output_shapes/
-:+��������������������������� "
identityIdentity:output:0*H
_input_shapes7
5:+���������������������������::22
StatefulPartitionedCallStatefulPartitionedCall: :& "
 
_user_specified_nameinputs: 
�
�
B__inference_sequential_layer_call_and_return_conditional_losses_83
conv2d_input0
,conv2d_statefulpartitionedcall_conv2d_kernel.
*conv2d_statefulpartitionedcall_conv2d_bias
identity��conv2d/StatefulPartitionedCall�
conv2d/StatefulPartitionedCallStatefulPartitionedCallconv2d_input,conv2d_statefulpartitionedcall_conv2d_kernel*conv2d_statefulpartitionedcall_conv2d_bias*)
_gradient_op_typePartitionedCall-57*G
fBR@
>__inference_conv2d_layer_call_and_return_conditional_losses_50*
Tout
2*-
config_proto

CPU

GPU2*0J 8*
Tin
2*/
_output_shapes
:��������� �
IdentityIdentity'conv2d/StatefulPartitionedCall:output:0^conv2d/StatefulPartitionedCall*
T0*/
_output_shapes
:��������� "
identityIdentity:output:0*6
_input_shapes%
#:���������  ::2@
conv2d/StatefulPartitionedCallconv2d/StatefulPartitionedCall: :, (
&
_user_specified_nameconv2d_input: 
�
�
__inference__wrapped_model_35
conv2d_input9
5sequential_conv2d_conv2d_readvariableop_conv2d_kernel8
4sequential_conv2d_biasadd_readvariableop_conv2d_bias
identity��(sequential/conv2d/BiasAdd/ReadVariableOp�'sequential/conv2d/Conv2D/ReadVariableOp�
'sequential/conv2d/Conv2D/ReadVariableOpReadVariableOp5sequential_conv2d_conv2d_readvariableop_conv2d_kernel*
dtype0*&
_output_shapes
: �
sequential/conv2d/Conv2DConv2Dconv2d_input/sequential/conv2d/Conv2D/ReadVariableOp:value:0*
T0*
strides
*
paddingVALID*/
_output_shapes
:��������� �
(sequential/conv2d/BiasAdd/ReadVariableOpReadVariableOp4sequential_conv2d_biasadd_readvariableop_conv2d_bias*
dtype0*
_output_shapes
: �
sequential/conv2d/BiasAddBiasAdd!sequential/conv2d/Conv2D:output:00sequential/conv2d/BiasAdd/ReadVariableOp:value:0*
T0*/
_output_shapes
:��������� |
sequential/conv2d/ReluRelu"sequential/conv2d/BiasAdd:output:0*
T0*/
_output_shapes
:��������� �
IdentityIdentity$sequential/conv2d/Relu:activations:0)^sequential/conv2d/BiasAdd/ReadVariableOp(^sequential/conv2d/Conv2D/ReadVariableOp*
T0*/
_output_shapes
:��������� "
identityIdentity:output:0*6
_input_shapes%
#:���������  ::2T
(sequential/conv2d/BiasAdd/ReadVariableOp(sequential/conv2d/BiasAdd/ReadVariableOp2R
'sequential/conv2d/Conv2D/ReadVariableOp'sequential/conv2d/Conv2D/ReadVariableOp: :, (
&
_user_specified_nameconv2d_input: 
�
�
(__inference_sequential_layer_call_fn_158

inputs)
%statefulpartitionedcall_conv2d_kernel'
#statefulpartitionedcall_conv2d_bias
identity��StatefulPartitionedCall�
StatefulPartitionedCallStatefulPartitionedCallinputs%statefulpartitionedcall_conv2d_kernel#statefulpartitionedcall_conv2d_bias*)
_gradient_op_typePartitionedCall-94*K
fFRD
B__inference_sequential_layer_call_and_return_conditional_losses_93*
Tout
2*-
config_proto

CPU

GPU2*0J 8*
Tin
2*/
_output_shapes
:��������� �
IdentityIdentity StatefulPartitionedCall:output:0^StatefulPartitionedCall*
T0*/
_output_shapes
:��������� "
identityIdentity:output:0*6
_input_shapes%
#:���������  ::22
StatefulPartitionedCallStatefulPartitionedCall: :& "
 
_user_specified_nameinputs: 
�
�
__inference__traced_save_196
file_prefix,
(savev2_conv2d_kernel_read_readvariableop*
&savev2_conv2d_bias_read_readvariableop
savev2_1_const

identity_1��MergeV2Checkpoints�SaveV2�SaveV2_1�
StringJoin/inputs_1Const"/device:CPU:0*<
value3B1 B+_temp_fc6260ebde1c45028045a82ca92012eb/part*
dtype0*
_output_shapes
: s

StringJoin
StringJoinfile_prefixStringJoin/inputs_1:output:0"/device:CPU:0*
N*
_output_shapes
: L

num_shardsConst*
value	B :*
dtype0*
_output_shapes
: f
ShardedFilename/shardConst"/device:CPU:0*
value	B : *
dtype0*
_output_shapes
: �
ShardedFilenameShardedFilenameStringJoin:output:0ShardedFilename/shard:output:0num_shards:output:0"/device:CPU:0*
_output_shapes
: �
SaveV2/tensor_namesConst"/device:CPU:0*�
valuexBvB6layer_with_weights-0/kernel/.ATTRIBUTES/VARIABLE_VALUEB4layer_with_weights-0/bias/.ATTRIBUTES/VARIABLE_VALUE*
dtype0*
_output_shapes
:q
SaveV2/shape_and_slicesConst"/device:CPU:0*
valueBB B *
dtype0*
_output_shapes
:�
SaveV2SaveV2ShardedFilename:filename:0SaveV2/tensor_names:output:0 SaveV2/shape_and_slices:output:0(savev2_conv2d_kernel_read_readvariableop&savev2_conv2d_bias_read_readvariableop"/device:CPU:0*
dtypes
2*
_output_shapes
 h
ShardedFilename_1/shardConst"/device:CPU:0*
value	B :*
dtype0*
_output_shapes
: �
ShardedFilename_1ShardedFilenameStringJoin:output:0 ShardedFilename_1/shard:output:0num_shards:output:0"/device:CPU:0*
_output_shapes
: �
SaveV2_1/tensor_namesConst"/device:CPU:0*1
value(B&B_CHECKPOINTABLE_OBJECT_GRAPH*
dtype0*
_output_shapes
:q
SaveV2_1/shape_and_slicesConst"/device:CPU:0*
valueB
B *
dtype0*
_output_shapes
:�
SaveV2_1SaveV2ShardedFilename_1:filename:0SaveV2_1/tensor_names:output:0"SaveV2_1/shape_and_slices:output:0savev2_1_const^SaveV2"/device:CPU:0*
dtypes
2*
_output_shapes
 �
&MergeV2Checkpoints/checkpoint_prefixesPackShardedFilename:filename:0ShardedFilename_1:filename:0^SaveV2	^SaveV2_1"/device:CPU:0*
T0*
N*
_output_shapes
:�
MergeV2CheckpointsMergeV2Checkpoints/MergeV2Checkpoints/checkpoint_prefixes:output:0file_prefix	^SaveV2_1"/device:CPU:0*
_output_shapes
 f
IdentityIdentityfile_prefix^MergeV2Checkpoints"/device:CPU:0*
T0*
_output_shapes
: s

Identity_1IdentityIdentity:output:0^MergeV2Checkpoints^SaveV2	^SaveV2_1*
T0*
_output_shapes
: "!

identity_1Identity_1:output:0*/
_input_shapes
: : : : 2(
MergeV2CheckpointsMergeV2Checkpoints2
SaveV2SaveV22
SaveV2_1SaveV2_1: :+ '
%
_user_specified_namefile_prefix: : 
�
�
!__inference_signature_wrapper_126
conv2d_input)
%statefulpartitionedcall_conv2d_kernel'
#statefulpartitionedcall_conv2d_bias
identity��StatefulPartitionedCall�
StatefulPartitionedCallStatefulPartitionedCallconv2d_input%statefulpartitionedcall_conv2d_kernel#statefulpartitionedcall_conv2d_bias**
_gradient_op_typePartitionedCall-121*&
f!R
__inference__wrapped_model_35*
Tout
2*-
config_proto

CPU

GPU2*0J 8*
Tin
2*/
_output_shapes
:��������� �
IdentityIdentity StatefulPartitionedCall:output:0^StatefulPartitionedCall*
T0*/
_output_shapes
:��������� "
identityIdentity:output:0*6
_input_shapes%
#:���������  ::22
StatefulPartitionedCallStatefulPartitionedCall: :, (
&
_user_specified_nameconv2d_input: 
�
�
B__inference_sequential_layer_call_and_return_conditional_losses_93

inputs0
,conv2d_statefulpartitionedcall_conv2d_kernel.
*conv2d_statefulpartitionedcall_conv2d_bias
identity��conv2d/StatefulPartitionedCall�
conv2d/StatefulPartitionedCallStatefulPartitionedCallinputs,conv2d_statefulpartitionedcall_conv2d_kernel*conv2d_statefulpartitionedcall_conv2d_bias*)
_gradient_op_typePartitionedCall-57*G
fBR@
>__inference_conv2d_layer_call_and_return_conditional_losses_50*
Tout
2*-
config_proto

CPU

GPU2*0J 8*
Tin
2*/
_output_shapes
:��������� �
IdentityIdentity'conv2d/StatefulPartitionedCall:output:0^conv2d/StatefulPartitionedCall*
T0*/
_output_shapes
:��������� "
identityIdentity:output:0*6
_input_shapes%
#:���������  ::2@
conv2d/StatefulPartitionedCallconv2d/StatefulPartitionedCall: :& "
 
_user_specified_nameinputs: 
�
�
(__inference_sequential_layer_call_fn_117
conv2d_input)
%statefulpartitionedcall_conv2d_kernel'
#statefulpartitionedcall_conv2d_bias
identity��StatefulPartitionedCall�
StatefulPartitionedCallStatefulPartitionedCallconv2d_input%statefulpartitionedcall_conv2d_kernel#statefulpartitionedcall_conv2d_bias**
_gradient_op_typePartitionedCall-112*L
fGRE
C__inference_sequential_layer_call_and_return_conditional_losses_111*
Tout
2*-
config_proto

CPU

GPU2*0J 8*
Tin
2*/
_output_shapes
:��������� �
IdentityIdentity StatefulPartitionedCall:output:0^StatefulPartitionedCall*
T0*/
_output_shapes
:��������� "
identityIdentity:output:0*6
_input_shapes%
#:���������  ::22
StatefulPartitionedCallStatefulPartitionedCall: :, (
&
_user_specified_nameconv2d_input: 
�
�
'__inference_sequential_layer_call_fn_99
conv2d_input)
%statefulpartitionedcall_conv2d_kernel'
#statefulpartitionedcall_conv2d_bias
identity��StatefulPartitionedCall�
StatefulPartitionedCallStatefulPartitionedCallconv2d_input%statefulpartitionedcall_conv2d_kernel#statefulpartitionedcall_conv2d_bias*)
_gradient_op_typePartitionedCall-94*K
fFRD
B__inference_sequential_layer_call_and_return_conditional_losses_93*
Tout
2*-
config_proto

CPU

GPU2*0J 8*
Tin
2*/
_output_shapes
:��������� �
IdentityIdentity StatefulPartitionedCall:output:0^StatefulPartitionedCall*
T0*/
_output_shapes
:��������� "
identityIdentity:output:0*6
_input_shapes%
#:���������  ::22
StatefulPartitionedCallStatefulPartitionedCall: :, (
&
_user_specified_nameconv2d_input: "�L
saver_filename:0StatefulPartitionedCall_1:0StatefulPartitionedCall_28"
saved_model_main_op

NoOp*>
__saved_model_init_op%#
__saved_model_init_op

NoOp*�
serving_default�
M
conv2d_input=
serving_default_conv2d_input:0���������  B
conv2d8
StatefulPartitionedCall:0��������� tensorflow/serving/predict:�K
�
layer-0
layer_with_weights-0
layer-1
trainable_variables
	variables
regularization_losses
	keras_api

signatures
_default_save_signature
 __call__
*!&call_and_return_all_conditional_losses"�
_tf_keras_sequential�{"class_name": "Sequential", "name": "sequential", "trainable": true, "expects_training_arg": true, "dtype": null, "batch_input_shape": null, "config": {"name": "sequential", "layers": [{"class_name": "Conv2D", "config": {"name": "conv2d", "trainable": true, "batch_input_shape": [null, 32, 32, 3], "dtype": "float32", "filters": 32, "kernel_size": [3, 3], "strides": [1, 1], "padding": "valid", "data_format": "channels_last", "dilation_rate": [1, 1], "activation": "relu", "use_bias": true, "kernel_initializer": {"class_name": "GlorotUniform", "config": {"seed": null, "dtype": "float32"}}, "bias_initializer": {"class_name": "Zeros", "config": {"dtype": "float32"}}, "kernel_regularizer": null, "bias_regularizer": null, "activity_regularizer": null, "kernel_constraint": null, "bias_constraint": null}}]}, "input_spec": {"class_name": "InputSpec", "config": {"dtype": null, "shape": null, "ndim": 4, "max_ndim": null, "min_ndim": null, "axes": {"-1": 3}}}, "activity_regularizer": null, "keras_version": "2.2.4-tf", "backend": "tensorflow", "model_config": {"class_name": "Sequential", "config": {"name": "sequential", "layers": [{"class_name": "Conv2D", "config": {"name": "conv2d", "trainable": true, "batch_input_shape": [null, 32, 32, 3], "dtype": "float32", "filters": 32, "kernel_size": [3, 3], "strides": [1, 1], "padding": "valid", "data_format": "channels_last", "dilation_rate": [1, 1], "activation": "relu", "use_bias": true, "kernel_initializer": {"class_name": "GlorotUniform", "config": {"seed": null, "dtype": "float32"}}, "bias_initializer": {"class_name": "Zeros", "config": {"dtype": "float32"}}, "kernel_regularizer": null, "bias_regularizer": null, "activity_regularizer": null, "kernel_constraint": null, "bias_constraint": null}}]}}}
�
trainable_variables
		variables

regularization_losses
	keras_api
"__call__
*#&call_and_return_all_conditional_losses"�
_tf_keras_layer�{"class_name": "InputLayer", "name": "conv2d_input", "trainable": true, "expects_training_arg": true, "dtype": "float32", "batch_input_shape": [null, 32, 32, 3], "config": {"batch_input_shape": [null, 32, 32, 3], "dtype": "float32", "sparse": false, "ragged": false, "name": "conv2d_input"}, "input_spec": null, "activity_regularizer": null}
�

kernel
bias
_callable_losses
trainable_variables
	variables
regularization_losses
	keras_api
$__call__
*%&call_and_return_all_conditional_losses"�
_tf_keras_layer�{"class_name": "Conv2D", "name": "conv2d", "trainable": true, "expects_training_arg": false, "dtype": "float32", "batch_input_shape": [null, 32, 32, 3], "config": {"name": "conv2d", "trainable": true, "batch_input_shape": [null, 32, 32, 3], "dtype": "float32", "filters": 32, "kernel_size": [3, 3], "strides": [1, 1], "padding": "valid", "data_format": "channels_last", "dilation_rate": [1, 1], "activation": "relu", "use_bias": true, "kernel_initializer": {"class_name": "GlorotUniform", "config": {"seed": null, "dtype": "float32"}}, "bias_initializer": {"class_name": "Zeros", "config": {"dtype": "float32"}}, "kernel_regularizer": null, "bias_regularizer": null, "activity_regularizer": null, "kernel_constraint": null, "bias_constraint": null}, "input_spec": {"class_name": "InputSpec", "config": {"dtype": null, "shape": null, "ndim": 4, "max_ndim": null, "min_ndim": null, "axes": {"-1": 3}}}, "activity_regularizer": null}
.
0
1"
trackable_list_wrapper
.
0
1"
trackable_list_wrapper
 "
trackable_list_wrapper
�

layers
metrics
trainable_variables
	variables
layer_regularization_losses
regularization_losses
non_trainable_variables
 __call__
_default_save_signature
*!&call_and_return_all_conditional_losses
&!"call_and_return_conditional_losses"
_generic_user_object
,
&serving_default"
signature_map
 "
trackable_list_wrapper
 "
trackable_list_wrapper
 "
trackable_list_wrapper
�

layers
metrics
trainable_variables
		variables
layer_regularization_losses

regularization_losses
non_trainable_variables
"__call__
*#&call_and_return_all_conditional_losses
&#"call_and_return_conditional_losses"
_generic_user_object
':% 2conv2d/kernel
: 2conv2d/bias
 "
trackable_list_wrapper
.
0
1"
trackable_list_wrapper
.
0
1"
trackable_list_wrapper
 "
trackable_list_wrapper
�

layers
metrics
trainable_variables
	variables
layer_regularization_losses
regularization_losses
non_trainable_variables
$__call__
*%&call_and_return_all_conditional_losses
&%"call_and_return_conditional_losses"
_generic_user_object
'
0"
trackable_list_wrapper
 "
trackable_list_wrapper
 "
trackable_list_wrapper
 "
trackable_list_wrapper
 "
trackable_list_wrapper
 "
trackable_list_wrapper
 "
trackable_list_wrapper
 "
trackable_list_wrapper
 "
trackable_list_wrapper
 "
trackable_list_wrapper
 "
trackable_list_wrapper
 "
trackable_list_wrapper
�2�
__inference__wrapped_model_35�
���
FullArgSpec
args� 
varargsjargs
varkw
 
defaults
 

kwonlyargs� 
kwonlydefaults
 
annotations� *3�0
.�+
conv2d_input���������  
�2�
(__inference_sequential_layer_call_fn_158
'__inference_sequential_layer_call_fn_99
(__inference_sequential_layer_call_fn_165
(__inference_sequential_layer_call_fn_117�
���
FullArgSpec1
args)�&
jself
jinputs

jtraining
jmask
varargs
 
varkw
 
defaults�
p 

 

kwonlyargs� 
kwonlydefaults� 
annotations� *
 
�2�
B__inference_sequential_layer_call_and_return_conditional_losses_83
C__inference_sequential_layer_call_and_return_conditional_losses_151
C__inference_sequential_layer_call_and_return_conditional_losses_140
B__inference_sequential_layer_call_and_return_conditional_losses_73�
���
FullArgSpec1
args)�&
jself
jinputs

jtraining
jmask
varargs
 
varkw
 
defaults�
p 

 

kwonlyargs� 
kwonlydefaults� 
annotations� *
 
�2��
���
FullArgSpec
args�
jself
jinputs
varargs
 
varkwjkwargs
defaults� 

kwonlyargs�

jtraining%
kwonlydefaults�

trainingp 
annotations� *
 
�2��
���
FullArgSpec
args�
jself
jinputs
varargs
 
varkwjkwargs
defaults� 

kwonlyargs�

jtraining%
kwonlydefaults�

trainingp 
annotations� *
 
�2�
#__inference_conv2d_layer_call_fn_62�
���
FullArgSpec
args�
jself
jinputs
varargs
 
varkw
 
defaults
 

kwonlyargs� 
kwonlydefaults
 
annotations� *7�4
2�/+���������������������������
�2�
>__inference_conv2d_layer_call_and_return_conditional_losses_50�
���
FullArgSpec
args�
jself
jinputs
varargs
 
varkw
 
defaults
 

kwonlyargs� 
kwonlydefaults
 
annotations� *7�4
2�/+���������������������������
5B3
!__inference_signature_wrapper_126conv2d_input�
__inference__wrapped_model_35|=�:
3�0
.�+
conv2d_input���������  
� "7�4
2
conv2d(�%
conv2d��������� �
(__inference_sequential_layer_call_fn_158g?�<
5�2
(�%
inputs���������  
p

 
� " ���������� �
'__inference_sequential_layer_call_fn_99mE�B
;�8
.�+
conv2d_input���������  
p

 
� " ���������� �
(__inference_sequential_layer_call_fn_165g?�<
5�2
(�%
inputs���������  
p 

 
� " ���������� �
(__inference_sequential_layer_call_fn_117mE�B
;�8
.�+
conv2d_input���������  
p 

 
� " ���������� �
B__inference_sequential_layer_call_and_return_conditional_losses_83zE�B
;�8
.�+
conv2d_input���������  
p 

 
� "-�*
#� 
0��������� 
� �
C__inference_sequential_layer_call_and_return_conditional_losses_151t?�<
5�2
(�%
inputs���������  
p 

 
� "-�*
#� 
0��������� 
� �
C__inference_sequential_layer_call_and_return_conditional_losses_140t?�<
5�2
(�%
inputs���������  
p

 
� "-�*
#� 
0��������� 
� �
B__inference_sequential_layer_call_and_return_conditional_losses_73zE�B
;�8
.�+
conv2d_input���������  
p

 
� "-�*
#� 
0��������� 
� �
#__inference_conv2d_layer_call_fn_62�I�F
?�<
:�7
inputs+���������������������������
� "2�/+��������������������������� �
>__inference_conv2d_layer_call_and_return_conditional_losses_50�I�F
?�<
:�7
inputs+���������������������������
� "?�<
5�2
0+��������������������������� 
� �
!__inference_signature_wrapper_126�M�J
� 
C�@
>
conv2d_input.�+
conv2d_input���������  "7�4
2
conv2d(�%
conv2d��������� 